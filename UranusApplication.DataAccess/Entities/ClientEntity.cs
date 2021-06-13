using ProyectoPuntoNet.DataAccess.Config;
using ProyectoPuntoNet.DataAccess.Contracts;
using ProyectoPuntoNet.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;

namespace ProyectoPuntoNet.DataAccess.Entities
{
    public class ClientEntity : BaseEntity<Client>, IEntity<Client>
    {
        private readonly string tableName;

        public ClientEntity()
        {
            tableName = "cliente";
        }

        public async Task<int> AddOne(Client data)
        {
            try
            {
                string SQL = string.Format(@"INSERT INTO {0}(nombres, cedula, direccion, genero, telefono) VALUES (@nombres, @cedula, @direccion, @genero, @telefono);", tableName);
                return await Execute(SQL, data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Client>> FindBy(string column, string value)
        {
            try
            {
                string SQL = string.Format(@"SELECT * FROM {0} WHERE {1}=@value ORDER BY id_cliente DESC", tableName, column);
                return await Query(SQL, new { value });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<Client> FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                string SQL = string.Format(@"DELETE FROM {0} WHERE id_cliente=@id", tableName);
                return await Execute(SQL, new { id });
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<IEnumerable<Client>> GetAll()
        {
            try
            {
                string SQL = string.Format("SELECT * FROM {0} ORDER BY id_cliente DESC;", tableName);
                return await Query(SQL, null);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> Update(Client data)
        {
            try
            {
                string SQL = string.Format(@"UPDATE {0} SET nombres=@nombres, cedula=@cedula, direccion=@direccion, genero=@genero, telefono=@telefono WHERE id_cliente=@id_cliente", tableName);
                return await Execute(SQL, data);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
