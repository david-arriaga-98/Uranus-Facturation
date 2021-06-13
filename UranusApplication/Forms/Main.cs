using ProyectoPuntoNet.DataAccess.Config;
using ProyectoPuntoNet.DataAccess.Contracts;
using ProyectoPuntoNet.DataAccess.Models;
using ProyectoPuntoNet.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace ProyectoPuntoNet.Forms
{
    public partial class Main : Form
    {
        private readonly IEntity<User> _entity;
        private User _usuario { get; set; }

        public Main(IEntity<User> entity, User usuario, bool fromSession)
        {
            _entity = entity;
            _usuario = usuario;
            verifySession(fromSession);
            InitializeComponent();
        }

        private async void verifySession(bool fromSession)
        {
            if (fromSession)
            {
                IList<User> userList = (await _entity.FindBy("id_usuario", _usuario.id_usuario.ToString())).ToList();
                if (userList.Count.Equals(0))
                {
                    goToLogin();
                    return;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            goToLogin();
        }

        private void goToLogin()
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

        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                txtName.Text = _usuario.nombres;
                Image image = Files.GetImage("users", _usuario.imagen_id);
                if (image != null)
                {
                    pictureBox1.Image = image;
                }
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Control control = new Control(_usuario, _entity);
            Dispose();
            control.Show();
        }

        private void Main_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
