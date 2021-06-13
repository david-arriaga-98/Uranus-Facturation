using ProyectoPuntoNet.DataAccess.Contracts;
using ProyectoPuntoNet.DataAccess.Models;
using ProyectoPuntoNet.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProyectoPuntoNet.Forms.Products
{
    public partial class AddProduct : Form
    {
        private Action<SelectedCatalog> _delegateAddProductToList;
        private IEntity<Catalog> _entityCatalogo;
        private IList<Catalog> _catalogos;

        private int currentID = -1;

        public AddProduct(Action<SelectedCatalog> delegateAddProductToList, IEntity<Catalog> entityCatalogo)
        {
            _delegateAddProductToList = delegateAddProductToList;
            _entityCatalogo = entityCatalogo;
            InitializeComponent();
            FillTable();
        }

        private async void FillTable()
        {
            try
            {
                tableProducts.Rows.Clear();
                _catalogos = (await _entityCatalogo.GetAll()).ToList();
                foreach (Catalog catalogo in _catalogos)
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
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (currentID.Equals(-1))
            {
                "Debes escoger algun artículo".ShowError();
            }
            else
            {
                string errorMsg = "";
                string quantity = txtQuantity.Text;
                string description = txtDesc.Text;

                if (description.IsEmpty() || quantity.IsEmpty())
                {
                    errorMsg = "Todos los campos son requeridos";
                }
                else
                {
                    if (!quantity.IsInteger())
                    {
                        errorMsg = "La cantidad solo debe ser números";
                    }
                    else
                    {
                        int quanti = Convert.ToInt32(quantity);
                        Catalog catalogo = _catalogos.Where(x => x.id_catalogo.Equals(currentID)).First();
                        if (quanti > catalogo.cantidad)
                        {
                            errorMsg = "La cantidad escogida es mayor a la disponible";
                        }
                        else
                        {
                            SelectedCatalog catalogoElegido = new SelectedCatalog()
                            {
                                cantidad = quanti,
                                catalogo = catalogo.id_catalogo,
                                descripcion = description,
                                total = (quanti * catalogo.precio),
                                precio = catalogo.precio
                            };
                            _delegateAddProductToList(catalogoElegido);
                            Dispose();
                            return;
                        }
                    }
                }
                errorMsg.ShowError();
            }
        }

        private void tableProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var row = tableProducts.CurrentRow;
                int id = (int)row.Cells[0].Value;

                if (!currentID.Equals(id))
                {
                    Catalog catalogo = _catalogos.Where(x => x.id_catalogo.Equals(id)).First();

                    var image = Files.GetImage("products", catalogo.imagen_id);
                    if (image == null)
                    {
                        pBProducts.Image = Properties.Resources.hojaRota;
                    }
                    else
                    {
                        pBProducts.Image = image;
                    }

                    txtName.Text = catalogo.nombre;
                    txtPrice.Text = catalogo.precio.ToString();
                    currentID = catalogo.id_catalogo;
                }
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }
    }
}
