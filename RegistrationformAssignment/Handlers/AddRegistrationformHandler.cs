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

/* GENERIC IMPLEMENTATION BEFORE DOMMEL
   public async Task<RegistrationformModel> Handle(AddRegistrationformCommand request, CancellationToken cancellationToken)
        {
            //Look for an alternative way with a mapper
            string sql = @"INSERT INTO registrationform (Gender, FirstName, LastName, 
                                Email, PhoneNumber, Residence, FieldOfExpertise, Education, 
                                WorkExperience, DesiredFunction, 
                                JobApplicationReason, DesiredLocation, FormComments) VALUES (@Gender, @FirstName,
                                @LastName, @Email, @PhoneNumber, @Residence, @FieldOfExpertise, @Education,
                                @WorkExperience, @DesiredFunction, @JobApplicationReason, @DesiredLocation, @FormComments)";
            await Task.FromResult(_cloudDataAccess.SaveData(sql, request.model, _configuration.GetConnectionString("google")));
            _logger.LogInformation($"Handling registrationform entry {request.model.FirstName} {request.model.LastName} to the database");
            return request.model;
        }
    }
 */