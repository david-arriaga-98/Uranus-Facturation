using FontAwesome.Sharp;
using ProyectoPuntoNet.DataAccess.Contracts;
using ProyectoPuntoNet.DataAccess.Models;
using ProyectoPuntoNet.Utils;
using System;
using System.Windows.Forms;

namespace ProyectoPuntoNet.Forms.Products
{
    public partial class CreateSale : Form
    {
        private readonly IEntity<PurchaseOrder> _entity;
        private readonly User _usuario;
        private readonly IEntity<Client> _entityClient;
        private Clients.Clients clients;
        private Client client { get; set; }
        private Action _fillTableDelegate { get; set; }

        public CreateSale(User usuario, IEntity<Client> entityClient, IEntity<PurchaseOrder> entity, Action fillTableDelegate, int count)
        {
            Random rnd = new Random();
            _entity = entity;
            _entityClient = entityClient;
            _usuario = usuario;
            clients = new Clients.Clients(_entityClient);
            _fillTableDelegate = fillTableDelegate;
            InitializeComponent();
            numFact.Text = "FA-" + rnd.Next(1000, 9999) + "-" + (count + 1);
        }

        private void CreateSale_Load(object sender, EventArgs e)
        {
            txtVName.Text = _usuario.nombres;
            tVEmail.Text = _usuario.email;
            tVPhone.Text = _usuario.telefono;
            tVSchedule.Text = _usuario.cedula;
        }

        private void BtnAddClient_Click(object sender, EventArgs e)
        {
            clients.FillTable();
            clients.PanelClient.Dock = DockStyle.Fill;
            ClientPanel.Controls.Add(clients.PanelClient);
            ClientPanel.Tag = clients.PanelClient;
            ClientPanel.Visible = true;
            PrincipalPanel.Visible = false;
            BtnAddOrder.IconChar = IconChar.Check;
            BtnAddOrder.Text = "Agregar";
            BtnClose.Text = "Volver";
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (BtnClose.Text.Equals("Volver"))
            {
                ClientPanel.Visible = false;
                PrincipalPanel.Visible = true;
                BtnClose.Text = "Salir";
                BtnClose.IconChar = IconChar.Times;
                BtnAddOrder.Text = "Guardar";
                BtnAddOrder.IconChar = IconChar.Save;
            }
            else
            {
                Dispose();
            }
        }

        private async void BtnAddOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (BtnAddOrder.Text.Equals("Agregar"))
                {
                    client = clients.GetCliente();
                    if (client != null)
                    {
                        ClientPanel.Visible = false;
                        PrincipalPanel.Visible = true;
                        BtnClose.Text = "Salir";
                        BtnClose.IconChar = IconChar.Times;
                        BtnAddOrder.Text = "Guardar";
                        BtnAddOrder.IconChar = IconChar.Save;

                        txtCName.Text = client.nombres;
                        txtCSchedule.Text = client.cedula;
                        txtCDirection.Text = client.direccion;
                        tCPhone.Text = client.telefono;
                    }
                }
                else
                {
                    if (client == null)
                    {
                        "Debes escoger un cliente".ShowError();
                    }
                    else
                    {
                        PurchaseOrder orden = new PurchaseOrder()
                        {
                            cliente = client.id_cliente,
                            codigo = numFact.Text,
                            fecha_cerrada = DateTime.Now,
                            fecha_generada = DateTime.Now,
                            vendedor = _usuario.id_usuario,
                        };
                        int value = await _entity.AddOne(orden);
                        if (value.Equals(1))
                        {
                            MessageBox.Show("Orden de compra creada correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _fillTableDelegate();
                            Dispose();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }
    }
}
