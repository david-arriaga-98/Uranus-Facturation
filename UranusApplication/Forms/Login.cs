using ProyectoPuntoNet.DataAccess.Config;
using ProyectoPuntoNet.DataAccess.Contracts;
using ProyectoPuntoNet.DataAccess.Models;
using ProyectoPuntoNet.Utils;
using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace ProyectoPuntoNet.Forms
{
    public partial class Login : Form
    {
        private readonly IEntity<User> _entity;

        public Login(IEntity<User> entity)
        {
            _entity = entity;
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register(_entity);
            register.Show();
            Dispose();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ExecuteLogin();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                User user = Session.GetSession();
                if (user != null)
                {
                    Main main = new Main(_entity, user, true);
                    Dispose();
                    main.Show();
                }
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }

        private void txtSchedule_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                ExecuteLogin();
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                ExecuteLogin();
            }
        }

        private async void ExecuteLogin()
        {
            try
            {
                string schedule = txtSchedule.Text;
                string pass = txtPass.Text;
                string errorMsg = "";

                if (schedule.IsEmpty() || pass.IsEmpty())
                {
                    errorMsg = "Todos los campos son requeridos";
                }
                else
                {
                    IEnumerable<User> users = await _entity.FindBy("cedula", schedule);
                    IList<User> userList = users.ToList();
                    if (userList.IsEmpty())
                    {
                        errorMsg = "Usuario y/o Contraseña incorrectos";
                    }
                    else
                    {
                        User user = userList[0];
                        if (user.contrasena.Equals(pass))
                        {
                            Session.SaveSession(user);
                            Main main = new Main(_entity, user, false);
                            Dispose();
                            main.Show();
                            return;
                        }
                        else
                        {
                            errorMsg = "Usuario y/o Contraseña incorrectos";
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

        private void Login_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
