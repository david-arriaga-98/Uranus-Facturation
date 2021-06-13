using ProyectoPuntoNet.DataAccess.Config;
using ProyectoPuntoNet.DataAccess.Contracts;
using ProyectoPuntoNet.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using ProyectoPuntoNet.DataAccess.Entities;

namespace ProyectoPuntoNet.Entities
{
    public class ECatalogo : BaseEntity<Catalog>, IEntity<Catalog>
    {
        private readonly string tableName;

        public ECatalogo()
        {
            tableName = "catalogo";
        }

        public async Task<int> AddOne(Catalog data)
        {
            try
            {
                string SQL = string.Format("INSERT INTO {0}(nombre, precio, cantidad, descripcion, imagen_id) VALUES (@nombre, @precio, @cantidad, @descripcion, @imagen_id);", tableName);
                return await Execute(SQL, data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<IEnumerable<Catalog>> FindBy(string column, string value)
        {
            throw new NotImplementedException();
        }

        public Task<Catalog> FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                string SQL = string.Format(@"DELETE FROM {0} WHERE id_catalogo=@id", tableName);
                return await Execute(SQL, new { id });
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<IEnumerable<Catalog>> GetAll()
        {
            try
            {
                string SQL = string.Format("SELECT * FROM {0} ORDER BY id_catalogo DESC", tableName);
                return await Query(SQL);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> Update(Catalog data)
        {
            try
            {
                string SQL = string.Format("UPDATE {0} SET nombre=@nombre, precio=@precio, cantidad=@cantidad, descripcion=@descripcion, imagen_id=@imagen_id WHERE id_catalogo=@id_catalogo", tableName);
                return await Execute(SQL, data);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
