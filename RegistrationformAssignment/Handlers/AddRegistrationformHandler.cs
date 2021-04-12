using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistrationformAssignment.DataAccess;
using RegistrationformAssignment.Commands;
using System.Threading;
using RegistrationformAssignment.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Dommel;
using Dapper;
using Npgsql;
using System.Data;

namespace RegistrationformAssignment.Handlers
{
    public class AddRegistrationformHandler : IRequestHandler<AddRegistrationformCommand, RegistrationformModel>
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public AddRegistrationformHandler(IConfiguration configuration, ILogger<AddRegistrationformHandler> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        public async Task<RegistrationformModel> Handle(AddRegistrationformCommand request, CancellationToken cancellationToken)
        {
            using (IDbConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("google")))
            {
                await connection.InsertAsync(request.model);
            }
            _logger.LogInformation($"Handling registrationform entry {request.model.FirstName} {request.model.LastName} to the database");
            return request.model;
        }
    }
}
