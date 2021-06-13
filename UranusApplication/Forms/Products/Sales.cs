using ProyectoPuntoNet.DataAccess.Contracts;
using ProyectoPuntoNet.DataAccess.Models;
using ProyectoPuntoNet.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace ProyectoPuntoNet.Forms.Products
{
    public partial class Sales : Form
    {
        private IEntity<PurchaseOrder> _entity;
        private IEntity<Client> _entityClient;

        private IList<PurchaseOrder> ordenesDeCompra;
        private User _usuario;

        private bool useFilters = false;
        private IList<PurchaseOrder> ordenesDeCompraFiltradas;

        public Sales()
        {
            InitializeComponent();
        }

        public async void FillTable()
        {
            try
            {
                tableSales.Rows.Clear();
                if (useFilters)
                {
                    FillToTable(ordenesDeCompraFiltradas);
                }
                else
                {
                    ordenesDeCompra = (await _entity.GetAll()).ToList();
                    FillToTable(ordenesDeCompra);
                }
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }

        private void FillToTable(IList<PurchaseOrder> ordenes)
        {
            foreach (PurchaseOrder orden in ordenes)
            {
                tableSales.Rows.Add(new object[] {
                            orden.id_orden_de_compra,
                            orden.codigo,
                            orden.estado ? "Cerrado" : "Abierto",
                            orden.subtotal,
                            orden.descuento,
                            orden.impuestos,
                            orden.total,
                            orden.fecha_generada
                        });
            }
        }

        private void Sales_Load(object sender, EventArgs e)
        {
            Control topLevelParent = (Control)TopLevelControl;
            _entity = topLevelParent._entityOrdenDeCompra;
            _entityClient = topLevelParent._entityCliente;
            _usuario = topLevelParent._usuario;

            FillTable();
        }

        private void showOrder_Click(object sender, EventArgs e)
        {
            /*ShowSale showSale = new ShowSale();
            showSale.ShowDialog();*/
        }

        private void BtnAddOrder_Click_1(object sender, EventArgs e)
        {
            Action FillTableDelegate = FillTable;
            CreateSale createSale = new CreateSale(_usuario, _entityClient, _entity, FillTableDelegate, ordenesDeCompra.Count);
            createSale.ShowDialog();
        }

        private void BtnAddProducts_Click(object sender, EventArgs e)
        {
            if (tableSales.Rows.Count > 0)
            {
                DataGridViewCellCollection cells = tableSales.CurrentRow.Cells;
                if (cells[2].Value.ToString().Equals("Cerrado"))
                {
                    "No se puede agregar productos en ordenes de compras cerradas".ShowError();
                }
                else
                {
                    int id = (int)cells[0].Value;
                    PurchaseOrder orden = ordenesDeCompra.Where(x => x.id_orden_de_compra.Equals(id)).First();
                    if (PanelPrincipal.Controls.Count > 0)
                        PanelPrincipal.Controls.Clear();
                    Facturation _form = new Facturation(orden);
                    _form.TopLevel = false;
                    _form.Dock = DockStyle.Fill;
                    PanelPrincipal.Controls.Add(_form);
                    PanelPrincipal.Tag = _form;
                    _form.Show();
                }
            }
        }

        private void ApplyFilters(DateTime dateFrom, DateTime dateTo, object state)
        {
            try
            {
                Type typeEntity = _entity.GetType();
                var method = typeEntity.GetMethod("GetFilters");
                ordenesDeCompraFiltradas = ((IEnumerable<PurchaseOrder>)method.Invoke(_entity, new object[] { dateFrom, dateTo, state })).ToList();
                useFilters = true;
                FillTable();
                BtnApplyFilter.Text = "Borrar Filtros";
                BtnApplyFilter.IconChar = FontAwesome.Sharp.IconChar.Eraser;
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }

        public delegate void DelegateApplyFilter(DateTime dateFrom, DateTime dateTo, object state);

        private void BtnApplyFilter_Click(object sender, EventArgs e)
        {
            if (BtnApplyFilter.Text.Equals("Aplicar Filtros"))
            {
                DelegateApplyFilter delegateApplyFilter = ApplyFilters;
                SalesApplyFilters applyFilters = new SalesApplyFilters(delegateApplyFilter);
                applyFilters.ShowDialog();
            }
            else
            {
                BtnApplyFilter.Text = "Aplicar Filtros";
                BtnApplyFilter.IconChar = FontAwesome.Sharp.IconChar.Filter;
                useFilters = false;
                FillTable();
            }
        }
    }
}
