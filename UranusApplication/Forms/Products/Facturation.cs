using ProyectoPuntoNet.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using ProyectoPuntoNet.DataAccess.Contracts;
using ProyectoPuntoNet.DataAccess.Entities;
using ProyectoPuntoNet.Utils;

namespace ProyectoPuntoNet.Forms.Products
{
    public partial class Facturation : Form
    {
        private IList<SelectedCatalog> productosEscogidos { get; set; }
        private PurchaseOrder _orden { get; set; }
        private IEntity<Catalog> _entityCatalogo { get; set; }
        private SelectedCatalogEntity _entityCatalogoElegido { get; set; }
        private PurchaseOrderEntity _entityOrdenDeCompra { get; set; }

        public Facturation(PurchaseOrder orden)
        {
            _orden = orden;
            InitializeComponent();
            numFact.Text = _orden.codigo;
        }

        private async void FillTable()
        {
            try
            {
                productosEscogidos = (await _entityCatalogoElegido.GetProductsFromTheOrder(_orden.id_orden_de_compra)).ToList();
                decimal suma = 0;
                tblProducts.Rows.Clear();
                foreach (SelectedCatalog productoEscogido in productosEscogidos)
                {
                    tblProducts.Rows.Add(new object[]
                    {
                    productoEscogido.id_catalogo_elegido,
                    productoEscogido.catalogo,
                    productoEscogido.cantidad,
                    productoEscogido.descripcion,
                    productoEscogido.precio,
                    productoEscogido.total
                    });
                    suma += productoEscogido.total;
                }
                lblSubtotal.Text = suma.ToString();
                Calculate();
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }

        public async void AddProductToList(SelectedCatalog productoEscogido)
        {
            try
            {
                productoEscogido.orden_de_compra = _orden.id_orden_de_compra;
                int result = await _entityCatalogoElegido.AddOne(productoEscogido);
                if (!result.Equals(3))
                {
                    "Ha ocurrido un error al ejecutar".ShowError();
                }
                productosEscogidos.Add(productoEscogido);
                FillTable();
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }

        private async void Facturation_Load(object sender, EventArgs e)
        {
            try
            {
                Control parentControl = (Control)TopLevelControl;
                _entityCatalogo = parentControl._entityCatalogo;
                _entityCatalogoElegido = (SelectedCatalogEntity)parentControl._entityCatalogoElegido;
                _entityOrdenDeCompra = (PurchaseOrderEntity)parentControl._entityOrdenDeCompra;


                User vendedor = (await parentControl._entity.FindBy("id_usuario", _orden.vendedor.ToString())).First();
                Client cliente = (await parentControl._entityCliente.FindBy("id_cliente", _orden.cliente.ToString())).First();
                FillTable();

                txtCName.Text = cliente.nombres;
                txtCSchedule.Text = cliente.cedula;
                txtCDirection.Text = cliente.direccion;
                tCPhone.Text = cliente.telefono;

                txtVName.Text = vendedor.nombres;
                tVSchedule.Text = vendedor.cedula;
                tVPhone.Text = vendedor.telefono;
                tVEmail.Text = vendedor.email;
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }


        private void btnAddArt_Click(object sender, EventArgs e)
        {
            Action<SelectedCatalog> delegateAddProductToList = AddProductToList;
            AddProduct addProduct = new AddProduct(delegateAddProductToList, _entityCatalogo);
            addProduct.ShowDialog();
        }

        private void btnDelArt_Click(object sender, EventArgs e)
        {
            //if (tblProducts.SelectedRows.Count.Equals(0))
            //{
            //    MessageBox.Show("Debes seleccionar una fila para eliminarla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}
            //else
            //{
            //    int id = (int)tblProducts.CurrentRow.Cells[1].Value;

            //    for (int i = 0; i < productosEscogidos.Count; i++)
            //    {
            //        if (productosEscogidos[i].id_producto_escogido.Equals(id))
            //        {
            //            foreach (Catalogo catalogo in catalogos)
            //            {
            //                if (catalogo.id_catalogo.Equals(productosEscogidos[i].id))
            //                {
            //                    catalogo.cantidad = catalogo.cantidad + productosEscogidos[i].cantidad;
            //                }
            //            }
            //            productosEscogidos.RemoveAt(i);
            //        }
            //    }
            //    fillTable();
            //}
        }

        private async void btnGenFact_Click(object sender, EventArgs e)
        {
            try
            {
                if (productosEscogidos.Count.Equals(0))
                {
                    "Debes escoger algun artículo".ShowError();
                }
                else
                {
                    string subtotal = lblSubtotal.Text;
                    string imp = txtImpuesto.Text;
                    string otros = txtOtros.Text;
                    imp = imp.Equals("") ? "0" : imp;
                    otros = otros.Equals("") ? "0" : otros;
                    double subt = Convert.ToDouble(subtotal);
                    double iva = subt * 0.12;
                    double impuestos = Convert.ToDouble(imp);
                    double descuento = Convert.ToDouble(otros);

                    PurchaseOrder orden = _orden;
                    orden.fecha_cerrada = DateTime.Now;
                    orden.descuento = Convert.ToDecimal(descuento);
                    orden.impuestos = Convert.ToDecimal(iva + impuestos);
                    orden.estado = true;
                    orden.subtotal = Convert.ToDecimal(subtotal);
                    orden.total = Convert.ToDecimal(subt + iva + impuestos - descuento);

                    int result = await _entityOrdenDeCompra.Update(orden);
                    if (result.Equals(1))
                    {
                        MessageBox.Show("Orden generada correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Control topParent = (Control)TopLevelControl;
                        topParent.panelPosition = -1;
                        topParent.btnSales_Click(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }

        private void txtImpuesto_KeyUp(object sender, KeyEventArgs e)
        {
            validateText(e, txtImpuesto);
        }

        private void Calculate()
        {
            try
            {
                string subtotal = lblSubtotal.Text;
                string imp = txtImpuesto.Text;
                string otros = txtOtros.Text;
                imp = imp.Equals("") ? "0" : imp;
                otros = otros.Equals("") ? "0" : otros;
                double subt = Convert.ToDouble(subtotal);
                subt = (subt * 0.12) + subt;
                double impuu = Convert.ToDouble(imp);
                double otrr = Convert.ToDouble(otros);
                lblTotal.Text = "" + (subt + (impuu) - (otrr));
            }
            catch (Exception)
            { }
        }

        private void validateText(KeyEventArgs e, TextBox textBox)
        {
            if (!e.KeyValue.Equals(13))
            {
                try
                {
                    string impuesto = textBox.Text;
                    if (!impuesto.Equals(""))
                    {
                        double valor = double.Parse(impuesto);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Solo se permiten números");
                    textBox.Text = "0";
                }
                Calculate();
            }
        }

        private void txtOtros_KeyUp(object sender, KeyEventArgs e)
        {
            validateText(e, txtOtros);
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Control topParent = (Control)TopLevelControl;
            topParent.panelPosition = -1;
            topParent.btnSales_Click(null, null);
        }
    }

}