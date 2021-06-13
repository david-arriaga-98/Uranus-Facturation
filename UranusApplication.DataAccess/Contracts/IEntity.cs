using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoPuntoNet.DataAccess.Contracts
{
    public interface IEntity<T>
    {
        Task<int> AddOne(T data);

        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> FindBy(string column, string value);

        Task<T> FindByID(int id);

        Task<int> Update(T data);

        Task<int> Delete(int id);
    }
}
