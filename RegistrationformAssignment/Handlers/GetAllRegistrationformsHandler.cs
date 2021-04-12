using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RegistrationformAssignment.DataAccess;
using RegistrationformAssignment.Queries;
using RegistrationformAssignment.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Dommel;
using Dapper;
using Npgsql;
using System.Data;

namespace RegistrationformAssignment.Handlers
{
    public class GetAllRegistrationformsHandler : IRequestHandler<GetAllRegistrationformsQuery, List<RegistrationformModel>>
    {
        private readonly IDataAccess _cloudDataAccess;
        private readonly IConfiguration _configuration;
        private readonly ILogger<GetAllRegistrationformsHandler> _logger;

        public GetAllRegistrationformsHandler(IDataAccess cloudDataAccess, IConfiguration configuration, ILogger<GetAllRegistrationformsHandler> logger)
        {
            _cloudDataAccess = cloudDataAccess;
            _configuration = configuration;
            _logger = logger;
        }

        /* public async Task<List<RegistrationformModel>> Handle(GetAllRegistrationformsQuery request, CancellationToken cancellationToken)
         {
             string sql = @"SELECT * FROM registrationform";
             var obj = await Task.FromResult(_cloudDataAccess.LoadData<RegistrationformModel, dynamic>(sql, new { }, _configuration.GetConnectionString("google")));
             _logger.LogInformation($"Retrieving {obj.Result.Count} entries from the database");
             return obj.Result.ToList();
         }*/

        //  DOMMEL IMPLEMENTATION
        public async Task<List<RegistrationformModel>> Handle(GetAllRegistrationformsQuery request, CancellationToken cancellationToken)
        {
            List<RegistrationformModel> newList = new();
            using (IDbConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("google")))
            {
                var forms = await connection.GetAllAsync<RegistrationformModel>();
                newList = forms.ToList();
            }
            _logger.LogInformation($"Retrieving {newList.Count} entries from the database");
            return newList;
        }

    }
}
