using ProyectoPuntoNet.DataAccess.Config;
using ProyectoPuntoNet.DataAccess.Contracts;
using ProyectoPuntoNet.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;

namespace ProyectoPuntoNet.DataAccess.Entities
{
    public class SelectedCatalogEntity : BaseEntity<SelectedCatalog>, IEntity<SelectedCatalog>
    {

        private readonly string tableName;

        public SelectedCatalogEntity()
        {
            tableName = "catalogo_elegido";
        }

        public async Task<int> AddOne(SelectedCatalog data)
        {
            try
            {
                using (var cnn = GetConnection())
                {
                    return await cnn.ExecuteAsync("Ingresar_Catalogo", new
                    {
                        data.catalogo,
                        orden = data.orden_de_compra,
                        data.cantidad,
                        data.descripcion,
                        data.precio
                    }, commandType: System.Data.CommandType.StoredProcedure);
                }
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
                string SQL = string.Format(@"DELETE FROM {0} WHERE id_catalogo_elegido=@id", tableName);
                return await Execute(SQL, new { id });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<SelectedCatalog>> FindBy(string column, string value)
        {
            try
            {
                string SQL = string.Format(@"SELECT * FROM {0} WHERE {1}=@value ORDER BY id_catalogo_elegido DESC", tableName, column);
                return await Query(SQL, new { value });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<SelectedCatalog> FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SelectedCatalog>> GetAll()
        {
            try
            {
                string SQL = string.Format("SELECT * FROM {0} ORDER BY id_catalogo_elegido DESC", tableName);
                return await Query(SQL);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<int> Update(SelectedCatalog data)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SelectedCatalog>> GetProductsFromTheOrder(int id)
        {
            try
            {
                string SQL = string.Format("SELECT * FROM {0} WHERE orden_de_compra=@id ORDER BY id_catalogo_elegido DESC", tableName);
                return await Query(SQL, new { id });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
