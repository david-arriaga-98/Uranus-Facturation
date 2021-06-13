using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using ProyectoPuntoNet.DataAccess.Config;

namespace ProyectoPuntoNet.DataAccess.Entities
{
    public class BaseEntity<T> : Database
    {
        protected async Task<IEnumerable<T>> Query(string SQL, object parameters = null)
        {
            try
            {
                using (var cnn = GetConnection())
                {
                    var result = await cnn.QueryAsync<T>(SQL, parameters);
                    cnn.Close();
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected async Task<int> Execute(string SQL, object parameters = null)
        {
            try
            {
                using (var cnn = GetConnection())
                {
                    var result = await cnn.ExecuteAsync(SQL, parameters);
                    cnn.Close();
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
