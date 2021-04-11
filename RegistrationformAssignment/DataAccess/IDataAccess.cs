using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegistrationformAssignment.DataAccess
{
    public interface IDataAccess
    {
        Task<List<T>> LoadData<T, U>(string sql,U parameters, string connectionstring);
        Task<T> SaveData<T>(string sql, T parameters, string connectionString);
    }
}