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

namespace RegistrationformAssignment.Handlers
{
    public class GetAllRegistrationformsHandler : IRequestHandler<GetAllRegistrationformsQuery, List<RegistrationformModel>>
    {
        private readonly DataAccessImplementation _cloudDataAccess;
        private readonly IConfiguration _configuration;

        public GetAllRegistrationformsHandler(DataAccessImplementation cloudDataAccess, IConfiguration configuration)
        {
            _cloudDataAccess = cloudDataAccess;
            _configuration = configuration;
        }

        public async Task<List<RegistrationformModel>> Handle(GetAllRegistrationformsQuery request, CancellationToken cancellationToken)
        {
            string sql = @"SELECT * FROM registrationform";
            var obj = await Task.FromResult(_cloudDataAccess.LoadData<RegistrationformModel, dynamic>(sql, new { }, _configuration.GetConnectionString("google")));
            return obj.Result.ToList();
        }
    }
}
