using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using Dommel;
using RegistrationformAssignment.Models;

namespace RegistrationformAssignment.DataAccess 
{
    public class DataAccessImplementation : IDataAccess
    {
        public async Task<List<T>> LoadData<T, U>(string sql, U parameters, string connectionstring)
        {
            using (IDbConnection connection = new NpgsqlConnection(connectionstring))
            {
                var rows = await connection.QueryAsync<T>(sql, parameters);

                return rows.ToList();
            }
        }

        public async Task<T> SaveData<T>(string sql, T parameters, string connectionString)
        {
            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                await connection.ExecuteAsync(sql, parameters);
                return parameters;
            }
        }
        //public async Task<T> SaveData<T>(string sql, T parameters, string connectionString)
        //{
        //    using (IDbConnection connection = new NpgsqlConnection(connectionString))
        //    {
        //        return await connection.InsertAsync<RegistrationformModel>(parameters);
        //        //return parameters;
        //    }
        //}
      /*  public async Task<int> SaveDataDommel(RegistrationformModel registrationform, string connectionString)
        {
            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                var obj = await connection.InsertAsync(registrationform);
                return registrationform.Id;
            }
        }*/

    }
}
