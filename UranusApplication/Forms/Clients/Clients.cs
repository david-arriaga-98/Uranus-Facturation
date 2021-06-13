using FontAwesome.Sharp;
using ProyectoPuntoNet.DataAccess.Contracts;
using ProyectoPuntoNet.DataAccess.Models;
using ProyectoPuntoNet.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Linq;

namespace ProyectoPuntoNet.Forms.Clients
{
    public partial class Clients : Form
    {
        private readonly IEntity<Client> _entity;
        private IList<Client> clients;

        private bool hasToUpdate = false;
        private int idToUpdate = 0;

        public Client GetCliente()
        {
            try
            {
                if (tableClients.Rows.Count > 0)
                {
                    DataGridViewCellCollection cells = tableClients.CurrentRow.Cells;
                    int id = (int)cells[0].Value;
                    return clients.Where(x => x.id_cliente.Equals(id)).First();
                }
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
            return null;
        }

        public Clients(IEntity<Client> entity)
        {
            _entity = entity;
            InitializeComponent();
            FillTable();
        }

        public async void FillTable()
        {
            try
            {
                tableClients.Rows.Clear();
                if (clients != null) clients.Clear();
                clients = (await _entity.GetAll()).ToList();
                foreach (var item in clients)
                {
                    tableClients.Rows.Add(new object[] { item.id_cliente, item.nombres, item.cedula, item.direccion, item.telefono, item.genero.Equals("M") ? "Masculino" : "Femenino" });
                }
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }

        private void CleanFields()
        {
            txtName.Text = "";
            txtSchedule.Text = "";
            txtDirection.Text = "";
            txtPhone.Text = "";
            cBoxGenre.SelectedIndex = -1;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string schedule = txtSchedule.Text;
                string direction = txtDirection.Text;
                string phone = txtPhone.Text;

                string errorMsg = "";

                if (name.IsEmpty() || schedule.IsEmpty() || direction.IsEmpty() || phone.IsEmpty() || cBoxGenre.SelectedIndex.Equals(-1))
                {
                    errorMsg = "Todos los campos deben ser completados";
                }
                else
                {
                    if (!schedule.IsInteger() || (schedule.Length < 10))
                    {
                        errorMsg = "La cédula es incorrecta";
                    }
                    else
                    {
                        if (!phone.IsInteger() || (phone.Length < 9))
                        {
                            errorMsg = "El teléfono es incorrecto";
                        }
                        else
                        {
                            Client client = new Client()
                            {
                                direccion = direction,
                                genero = cBoxGenre.SelectedIndex.Equals(0) ? "M" : "F",
                                nombres = name,
                                cedula = schedule,
                                telefono = phone,
                            };
                            int result = -1;
                            string message;

                            if (hasToUpdate)
                            {
                                DialogResult dialogResult = MessageBox.Show("¿Seguro que deseas editar este cliente?", "Escoja una opción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (dialogResult.Equals(DialogResult.Yes))
                                {
                                    client.id_cliente = idToUpdate;
                                    result = await _entity.Update(client);
                                    message = "Cliente actualizado correctamente";
                                    btnEdit.Text = "Editar";
                                    btnEdit.IconChar = IconChar.Edit;
                                    idToUpdate = 0;
                                    hasToUpdate = false;
                                }
                                else
                                {
                                    return;
                                }

                            }
                            else
                            {
                                result = await _entity.AddOne(client);
                                message = "Cliente Guardado correctamente";
                            }

                            if (result.Equals(1))
                            {
                                MessageBox.Show(message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CleanFields();
                                FillTable();
                                return;
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
                if (tableClients.Rows.Count > 0)
                {
                    DataGridViewCellCollection cells = tableClients.CurrentRow.Cells;
                    int id = (int)cells[0].Value;
                    if (btnEdit.Text.Equals("Cancelar"))
                    {
                        CleanFields();
                        btnEdit.Text = "Editar";
                        btnEdit.IconChar = IconChar.Edit;
                        idToUpdate = 0;
                        hasToUpdate = false;
                    }
                    else
                    {
                        if (!idToUpdate.Equals(id))
                        {
                            CleanFields();
                            txtName.Text = cells[1].Value.ToString();
                            txtSchedule.Text = cells[2].Value.ToString();
                            txtDirection.Text = cells[3].Value.ToString();
                            txtPhone.Text = cells[4].Value.ToString();

                            if (cells[5].Value.ToString().Equals("Masculino"))
                            {
                                cBoxGenre.SelectedIndex = 0;
                            }
                            else
                            {
                                cBoxGenre.SelectedIndex = 1;
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
                if (tableClients.Rows.Count > 0)
                {
                    DataGridViewCellCollection cells = tableClients.CurrentRow.Cells;
                    int id = (int)cells[0].Value;
                    DialogResult dialogResult = MessageBox.Show("¿Seguro que deseas eliminar este cliente?", "Escoja una opción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult.Equals(DialogResult.Yes))
                    {
                        int result = await _entity.Delete(id);
                        if (result.Equals(1))
                        {
                            MessageBox.Show("cliente eliminado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CleanFields();
                            FillTable();
                            btnEdit.Text = "Editar";
                            btnEdit.IconChar = IconChar.Edit;
                            idToUpdate = 0;
                            hasToUpdate = false;
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
