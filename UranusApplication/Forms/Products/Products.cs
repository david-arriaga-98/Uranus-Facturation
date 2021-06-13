using ProyectoPuntoNet.DataAccess.Contracts;
using ProyectoPuntoNet.DataAccess.Models;
using ProyectoPuntoNet.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using FontAwesome.Sharp;
using System.Data.SqlClient;

namespace ProyectoPuntoNet.Forms.Products
{
    public partial class Products : Form
    {
        private readonly IEntity<Catalog> _entity;

        private IList<Catalog> catalogos { get; set; }
        private bool hasToUpdate = false;
        private int idToUpdate = 0;


        public Products(IEntity<Catalog> entity)
        {
            _entity = entity;
            InitializeComponent();
            openFileDialog1.FileName = "";
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            fillTable();
        }

        private async void fillTable()
        {
            tableProducts.Rows.Clear();
            catalogos = (await _entity.GetAll()).ToList();
            foreach (Catalog catalogo in catalogos)
            {
                tableProducts.Rows.Add(new object[] {
                    catalogo.id_catalogo,
                    catalogo.nombre,
                    catalogo.precio,
                    catalogo.cantidad,
                    catalogo.descripcion,
                    catalogo.imagen_id,
                });
            }
        }

        private void Products_Load(object sender, EventArgs e)
        {
            fillTable();
        }

        private void pBProducts_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG)|*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromStream(openFileDialog1.OpenFile());
                pBProducts.Image = image;
            }
        }

        private void cleanFields()
        {
            txtName.Text = "";
            txtDesc.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
            pBProducts.Image = null;
            openFileDialog1.Reset();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string price = txtPrice.Text;
                string quantity = txtQuantity.Text;
                string desc = txtDesc.Text;
                string errorMsg = "";

                price = price.Replace('.', ',');

                if (name.IsEmpty() || price.IsEmpty() || quantity.IsEmpty() || desc.IsEmpty())
                {
                    errorMsg = "Todos los campos deben ser completados";
                }
                else
                {
                    if (!price.IsDouble() || !quantity.IsInteger())
                    {
                        errorMsg = "Hay un error, verifica tus datos y vuelve a intentarlo";
                    }
                    else
                    {
                        int result = -1;

                        if (hasToUpdate)
                        {
                            DialogResult dialogResult = MessageBox.Show("¿Seguro que deseas editar este producto?", "Escoja una opción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (dialogResult.Equals(DialogResult.Yes))
                            {
                                Catalog catalogo = catalogos.Where(x => x.id_catalogo.Equals(idToUpdate)).First();
                                if (!openFileDialog1.FileName.Equals(""))
                                {
                                    string fileExt = Path.GetExtension(openFileDialog1.FileName);
                                    using (Stream stream = openFileDialog1.OpenFile())
                                    {
                                        string oldFileName = Files.filesPath + @"\Images\" + catalogo.imagen_id;
                                        string fileName = "";
                                        if (!File.Exists(oldFileName))
                                        {
                                            fileName = Guid.NewGuid().ToString();
                                        }
                                        else
                                        {
                                            fileName = Path.GetFileNameWithoutExtension(oldFileName);
                                            Files.DeleteImage("products", catalogo.imagen_id);
                                        }
                                        Files.SaveImage(stream, "products", fileName, fileExt);
                                        catalogo.imagen_id = fileName + fileExt;
                                    }
                                }
                                catalogo.cantidad = Convert.ToInt32(quantity);
                                catalogo.descripcion = desc;
                                catalogo.nombre = name;
                                catalogo.precio = Convert.ToDecimal(price);
                                result = await _entity.Update(catalogo);
                                idToUpdate = 0;
                                hasToUpdate = false;

                                btnEdit.Text = "Editar";
                                btnEdit.IconChar = IconChar.Edit;

                                if (result.Equals(1))
                                {
                                    MessageBox.Show("Producto actualizado Correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    cleanFields();
                                    fillTable();
                                    return;
                                }
                                else
                                {
                                    errorMsg = "Ha ocurrido un error";
                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            if (openFileDialog1.FileName.Equals(""))
                            {
                                errorMsg = "Debes escoger una imagen para este producto";
                            }
                            else
                            {
                                string imgName = Guid.NewGuid().ToString();
                                string fileExt = Path.GetExtension(openFileDialog1.FileName);
                                using (Stream stream = openFileDialog1.OpenFile())
                                {
                                    Files.SaveImage(stream, "products", imgName, fileExt);
                                }
                                result = await _entity.AddOne(new Catalog()
                                {
                                    cantidad = Convert.ToInt32(quantity),
                                    descripcion = desc,
                                    nombre = name,
                                    precio = Convert.ToDecimal(price),
                                    imagen_id = imgName + fileExt
                                });
                                if (result.Equals(1))
                                {
                                    MessageBox.Show("Producto guardado Correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    cleanFields();
                                    fillTable();
                                    return;
                                }
                                else
                                {
                                    errorMsg = "Ha ocurrido un error";
                                }
                            }
                        }
                    }
                }
                errorMsg.ShowError();
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (tableProducts.Rows.Count > 0)
                {
                    DataGridViewCellCollection cells = tableProducts.CurrentRow.Cells;
                    int id = (int)cells[0].Value;
                    if (btnEdit.Text.Equals("Cancelar"))
                    {
                        cleanFields();
                        btnEdit.Text = "Editar";
                        btnEdit.IconChar = IconChar.Edit;
                        idToUpdate = 0;
                        hasToUpdate = false;
                    }
                    else
                    {
                        if (!idToUpdate.Equals(id))
                        {
                            cleanFields();
                            txtName.Text = cells[1].Value.ToString();
                            txtPrice.Text = cells[2].Value.ToString();
                            txtQuantity.Text = cells[3].Value.ToString();
                            txtDesc.Text = cells[4].Value.ToString();

                            Image image = Files.GetImage("products", cells[5].Value.ToString());
                            if (image != null)
                            {
                                pBProducts.Image = image;
                            }
                            else
                            {
                                pBProducts.Image = Properties.Resources.hojaRota;
                            }
                            hasToUpdate = true;
                            idToUpdate = id;
                            btnEdit.Text = "Cancelar";
                            btnEdit.IconChar = IconChar.TimesCircle;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (tableProducts.Rows.Count > 0)
                {
                    DataGridViewCellCollection cells = tableProducts.CurrentRow.Cells;
                    int id = (int)cells[0].Value;
                    DialogResult dialogResult = MessageBox.Show("¿Seguro que deseas eliminar este producto?", "Escoja una opción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult.Equals(DialogResult.Yes))
                    {
                        string img = cells[5].Value.ToString();
                        int result = await _entity.Delete(id);

                        if (result.Equals(1))
                        {
                            MessageBox.Show("Producto eliminado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cleanFields();
                            fillTable();
                            Files.DeleteImage("products", img);
                            btnEdit.Text = "Editar";
                            btnEdit.IconChar = IconChar.Edit;
                            idToUpdate = 0;
                            hasToUpdate = false;
                        }
                        else
                        {
                            "Ha ocurrido un error al eliminar el producto".ShowError();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number.Equals(547))
                {
                    "Este producto esta siendo utilizado, no se puede eliminar".ShowError();
                }
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }


    }



}
