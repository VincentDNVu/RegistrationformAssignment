using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RegistrationformAssignment.DataAccess;
using RegistrationformAssignment.Queries;
using RegistrationformAssignment.Models;

namespace RegistrationformAssignment.Handlers
{
    public class GetAllRegistrationformsHandler : IRequestHandler<GetAllRegistrationformsQuery, List<RegistrationformModel>>
    {
        private readonly DataAccessImplementation _cloudDataAccess;
        public GetAllRegistrationformsHandler(DataAccessImplementation cloudDataAccess)
        {
            _cloudDataAccess = cloudDataAccess;
        }

        public async Task<List<RegistrationformModel>> Handle(GetAllRegistrationformsQuery request, CancellationToken cancellationToken)
        {
            string connectionString = "Server=127.0.0.1;Port=5432;database=testdemo;user id=postgres;password=admin123";
            string sql = @"SELECT * FROM registrationform2";
            var obj = await Task.FromResult(_cloudDataAccess.LoadData<RegistrationformModel, dynamic>(sql, new { }, connectionString));
            return obj.Result.ToList();
        }
    }
}
