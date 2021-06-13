using ProyectoPuntoNet.DataAccess.Contracts;
using ProyectoPuntoNet.DataAccess.Models;
using ProyectoPuntoNet.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ProyectoPuntoNet.Forms
{
    public partial class Register : Form
    {
        private readonly IEntity<User> _entity;

        public Register(IEntity<User> entity)
        {
            _entity = entity;
            InitializeComponent();
        }

        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string schedule = txtSchedule.Text;
                string email = txtEmail.Text;
                string phone = txtPhone.Text;
                string pass = txtPass.Text;
                string pass_conf = txtPassConf.Text;

                string errorMsg = "";
                if (name.IsEmpty() || schedule.IsEmpty() || email.IsEmpty() || phone.IsEmpty() || pass.IsEmpty() || pass_conf.IsEmpty())
                {
                    errorMsg = "Todos los campos deben ser completados";
                }
                else
                {
                    if (schedule.IsInteger() && !(schedule.Length < 10))
                    {
                        if (email.IsEmail())
                        {
                            if (phone.IsInteger() && !(phone.Length < 9))
                            {
                                if (pass.Equals(pass_conf))
                                {
                                    IList<User> users = (await _entity.FindBy("cedula", schedule)).ToList();
                                    if (!users.IsEmpty())
                                    {
                                        errorMsg = "Ya existe un usuario con esta cédula";
                                    }
                                    else
                                    {
                                        User user;
                                        if (txtFile.Text.Equals(""))
                                        {
                                            user = new User()
                                            {
                                                cedula = schedule,
                                                email = email,
                                                nombres = name,
                                                telefono = phone,
                                                imagen_id = "NaI",
                                                contrasena = pass
                                            };
                                        }
                                        else
                                        {
                                            string imgName = Guid.NewGuid().ToString();
                                            string fileExt = Path.GetExtension(openFileDialog1.FileName);
                                            using (Stream stream = openFileDialog1.OpenFile())
                                            {
                                                Files.SaveImage(stream, "users", imgName, fileExt);
                                            }
                                            user = new User()
                                            {
                                                cedula = schedule,
                                                email = email,
                                                nombres = name,
                                                telefono = phone,
                                                imagen_id = imgName + fileExt,
                                                contrasena = pass
                                            };
                                        }
                                        if ((await _entity.AddOne(user)).Equals(1))
                                        {
                                            MessageBox.Show("Usuario creado correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            Login login = new Login(_entity);
                                            login.Show();
                                            Dispose();
                                            return;
                                        }
                                        else
                                        {
                                            errorMsg = "Ha ocurrido un error al guardar el registro";
                                        }
                                    }
                                }
                                else
                                {
                                    errorMsg = "Las contraseñas no coinciden";
                                }
                            }
                            else
                            {
                                errorMsg = "El número de teléfono es incorrecto";
                            }
                        }
                        else
                        {
                            errorMsg = "El correo electrónico no es válido";
                        }
                    }
                    else
                    {
                        errorMsg = "La cédula no es válida";
                    }
                }
                errorMsg.ShowError();
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }

        private void btnRet_Click(object sender, EventArgs e)
        {
            Login login = new Login(_entity);
            login.Show();
            Dispose();
        }

        private void btnOpenDialog_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG)|*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = openFileDialog1.FileName;
            }
        }
    }
}
