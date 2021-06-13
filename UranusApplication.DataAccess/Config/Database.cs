using System;
using System.Data.SqlClient;

namespace ProyectoPuntoNet.DataAccess.Config
{
    public class Database
    {
        private readonly string connectionString;

        protected Database()
        {
            connectionString = @"Server=(localdb)\MSSQLLocalDB; DataBase=DB_Proyecto_Parcial; Integrated Security = True";
        }

        protected SqlConnection GetConnection()
        {
            try
            {
                SqlConnection cnn = new SqlConnection(connectionString);
                return cnn;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
