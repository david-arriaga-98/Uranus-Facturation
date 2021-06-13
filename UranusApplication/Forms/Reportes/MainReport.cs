using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPuntoNet.Forms.Reportes
{
    public partial class MainReport : Form
    {
        public MainReport()
        {
            InitializeComponent();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            if (PanelPrincipal.Controls.Count > 0)
                PanelPrincipal.Controls.Clear();
            SalesReport sales = new SalesReport();
            sales.TopLevel = false;
            sales.Dock = DockStyle.Fill;
            PanelPrincipal.Controls.Add(sales);
            PanelPrincipal.Tag = sales;
            sales.Show();

        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            if (PanelPrincipal.Controls.Count > 0)
                PanelPrincipal.Controls.Clear();
            ProductReport product = new ProductReport();
            product.TopLevel = false;
            product.Dock = DockStyle.Fill;
            PanelPrincipal.Controls.Add(product);
            PanelPrincipal.Tag = product;
            product.Show();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            if (PanelPrincipal.Controls.Count > 0)
                PanelPrincipal.Controls.Clear();
            UserReport user = new UserReport();
            user.TopLevel = false;
            user.Dock = DockStyle.Fill;
            PanelPrincipal.Controls.Add(user);
            PanelPrincipal.Tag = user;
            user.Show();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            if (PanelPrincipal.Controls.Count > 0)
                PanelPrincipal.Controls.Clear();
            ClientReport client = new ClientReport();
            client.TopLevel = false;
            client.Dock = DockStyle.Fill;
            PanelPrincipal.Controls.Add(client);
            PanelPrincipal.Tag = client;
            client.Show();
        }
    }
}
