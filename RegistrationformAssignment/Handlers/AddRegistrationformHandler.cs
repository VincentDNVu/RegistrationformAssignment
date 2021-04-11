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

namespace RegistrationformAssignment.Handlers
{
    public class AddRegistrationformHandler : IRequestHandler<AddRegistrationformCommand, RegistrationformModel>
    {
        private readonly DataAccessImplementation _cloudDataAccess;
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public AddRegistrationformHandler(DataAccessImplementation cloudDataAccess, IConfiguration configuration /*ILogger logger*/)
        {
            _cloudDataAccess = cloudDataAccess;
            _configuration = configuration;
           // _logger = logger;
        }

        public async Task<RegistrationformModel> Handle(AddRegistrationformCommand request, CancellationToken cancellationToken)
        {
            string sql = @"INSERT INTO registrationform (Gender, FirstName, LastName, 
                                Email, PhoneNumber, Residence, FieldOfExpertise, Education, 
                                WorkExperience, DesiredFunction, 
                                JobApplicationReason, DesiredLocation) VALUES (@Gender, @FirstName,
                                @LastName, @Email, @PhoneNumber, @Residence, @FieldOfExpertise, @Education,
                                @WorkExperience, @DesiredFunction, @JobApplicationReason, @DesiredLocation)";
            await Task.FromResult(_cloudDataAccess.SaveData(sql, request.model, _configuration.GetConnectionString("google")));
            //_logger.LogInformation($"Sending registrationform entry {request.model.FirstName} {request.model.LastName} to the database");
            return request.model;
        }
    }
}
