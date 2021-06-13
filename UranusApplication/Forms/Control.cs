using ProyectoPuntoNet.DataAccess.Config;
using ProyectoPuntoNet.DataAccess.Contracts;
using ProyectoPuntoNet.DataAccess.Entities;
using ProyectoPuntoNet.DataAccess.Models;
using ProyectoPuntoNet.Entities;
using ProyectoPuntoNet.Utils;
using System;
using System.Windows.Forms;

namespace ProyectoPuntoNet.Forms
{
    public partial class Control : Form
    {
        public readonly User _usuario;
        public readonly IEntity<User> _entity;
        public readonly IEntity<Catalog> _entityCatalogo;
        public readonly IEntity<Client> _entityCliente;
        public readonly IEntity<PurchaseOrder> _entityOrdenDeCompra;
        public readonly IEntity<SelectedCatalog> _entityCatalogoElegido;

        private Form actualForm { get; set; }
        public int panelPosition = -1;

        public Control(User usuario, IEntity<User> entity)
        {
            _entity = entity;
            _usuario = usuario;
            _entityCatalogo = new ECatalogo();
            _entityCliente = new ClientEntity();
            _entityOrdenDeCompra = new PurchaseOrderEntity();
            _entityCatalogoElegido = new SelectedCatalogEntity();
            InitializeComponent();
            container.BringToFront();
        }

        private void Control_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void PaintContainer(object form)
        {
            if (container.Controls.Count > 0) container.Controls.Clear();
            Form _form = form as Form;
            _form.TopLevel = false;
            _form.Dock = DockStyle.Fill;
            container.Controls.Add(_form);
            container.Tag = _form;
            _form.Show();
        }

        public void CleanContainer()
        {
            if (actualForm != null) actualForm.Dispose();
        }

        private void btnGProduct_Click(object sender, EventArgs e)
        {
            if (!panelPosition.Equals(0))
            {
                CleanContainer();
                actualForm = new Products.Products(_entityCatalogo);
                PaintContainer(actualForm);
                panelPosition = 0;
            }
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            if (!panelPosition.Equals(2))
            {
                CleanContainer();
                actualForm = new Clients.Clients(_entityCliente);
                PaintContainer(actualForm);
                panelPosition = 2;
            }
        }

        private void btnCloseSession_Click(object sender, EventArgs e)
        {
            try
            {
                Login login = new Login(_entity);
                Session.QuitSession();
                Dispose();
                login.Show();
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }

        public void btnSales_Click(object sender, EventArgs e)
        {
            if (!panelPosition.Equals(1))
            {
                CleanContainer();
                actualForm = new Products.Sales();
                PaintContainer(actualForm);
                panelPosition = 1;
            }
        }

        public void btnReports_Click(object sender, EventArgs e)
        {
            if (!panelPosition.Equals(3))
            {
                CleanContainer();
                actualForm = new Reportes.MainReport();
                PaintContainer(actualForm);
                panelPosition = 3;
            }
        }
    }
}
