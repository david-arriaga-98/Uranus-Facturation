using Dapper;
using ProyectoPuntoNet.DataAccess.Config;
using ProyectoPuntoNet.DataAccess.Contracts;
using ProyectoPuntoNet.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ProyectoPuntoNet.DataAccess.Entities
{
    public class PurchaseOrderEntity : BaseEntity<PurchaseOrder>, IEntity<PurchaseOrder>
    {
        private readonly string tableName;

        public PurchaseOrderEntity()
        {
            tableName = "orden_de_compra";
        }

        public async Task<int> AddOne(PurchaseOrder data)
        {
            try
            {
                string SQL = string.Format(@"INSERT INTO {0}(cliente, vendedor, codigo, fecha_generada, fecha_cerrada, subtotal, descuento) VALUES (@cliente, @vendedor, @codigo, @fecha_generada, @fecha_cerrada, @subtotal, @descuento);", tableName);
                return await Execute(SQL, data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<IEnumerable<PurchaseOrder>> FindBy(string column, string value)
        {
            throw new NotImplementedException();
        }

        public Task<PurchaseOrder> FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }


        public async Task<IEnumerable<PurchaseOrder>> GetAll()
        {
            try
            {
                string SQL = string.Format("SELECT * FROM {0} ORDER BY id_orden_de_compra DESC", tableName);
                return await Query(SQL, null);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> Update(PurchaseOrder data)
        {
            try
            {
                string SQL = string.Format(@"UPDATE {0} SET estado=@estado, subtotal=@subtotal, descuento=@descuento, impuestos=@impuestos, total=@total, fecha_cerrada=@fecha_cerrada WHERE id_orden_de_compra=@id_orden_de_compra", tableName);
                return await Execute(SQL, data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<PurchaseOrder> GetFilters(DateTime dFrom, DateTime dTo, object state)
        {
            try
            {

                using (var cnn = GetConnection())
                {
                    string SQL = string.Format("SELECT * FROM {0} WHERE fecha_generada BETWEEN CONVERT(DATETIME,'{1}',103) AND CONVERT(DATETIME,'{2}', 103)", tableName, dFrom.ToString("dd/MM/yyyy"), dTo.ToString("dd/MM/yyyy"));
                    if (state != null)
                    {
                        bool statee = (bool)state;
                        if (statee)
                        {
                            SQL += " AND estado=0";
                        }
                        else
                        {
                            SQL += " AND estado=1";
                        }
                    }
                    SQL += " ORDER BY id_orden_de_compra DESC";
                    return cnn.Query<PurchaseOrder>(SQL);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
