using ProyectoPuntoNet.DataAccess.Config;
using ProyectoPuntoNet.DataAccess.Contracts;
using ProyectoPuntoNet.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;

namespace ProyectoPuntoNet.DataAccess.Entities
{
    public class UserEntity : BaseEntity<User>, IEntity<User>
    {
        private readonly string tableName;

        public UserEntity()
        {
            tableName = "usuario";
        }

        public async Task<int> AddOne(User data)
        {
            try
            {
                string SQL = string.Format(@"
                        INSERT INTO {0}(nombres, cedula, telefono, email, contrasena, imagen_id) 
                            VALUES
                        (@nombres, @cedula, @telefono, @email, @contrasena, @imagen_id);", tableName);
                return await Execute(SQL, data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                string SQL = string.Format(@"DELETE FROM {0} WHERE id_usuario=@id", tableName);
                return await Execute(SQL, new { id });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<User>> FindBy(string column, string value)
        {
            try
            {
                string SQL = string.Format(@"SELECT * FROM {0} WHERE {1}=@value ORDER BY id_usuario DESC", tableName, column);
                return await Query(SQL, new { value });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<User> FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            try
            {
                string SQL = string.Format(@"SELECT * FROM {0} ORDER BY id_usuario DESC", tableName);
                return await Query(SQL);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> Update(User data)
        {
            try
            {
                string SQL = string.Format(@"UPDATE {0} SET nombres=@nombres, cedula=@cedula, telefono=@telefono, email=@email, contrasena=@contrasena, imagen_id=@imagen_id WHERE id_usuario=@id_usuario", tableName);
                return await Execute(SQL, data);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
