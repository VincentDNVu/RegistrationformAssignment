using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistrationformAssignment.DataAccess;
using RegistrationformAssignment.Commands;
using System.Threading;
using RegistrationformAssignment.Models;

namespace RegistrationformAssignment.Handlers
{
    public class AddRegistrationformHandler : IRequestHandler<AddRegistrationformCommand, RegistrationformModel>
    {
        private readonly DataAccessImplementation _cloudDataAccess;
        public AddRegistrationformHandler(DataAccessImplementation cloudDataAccess)
        {
            _cloudDataAccess = cloudDataAccess;
        }

        public async Task<RegistrationformModel> Handle(AddRegistrationformCommand request, CancellationToken cancellationToken)
        {
            string connectionString = "Server=127.0.0.1;Port=5432;database=testdemo;user id=postgres;password=admin123";
            string sql = @"INSERT INTO registrationform2 (Gender, FirstName, LastName, 
                                Email, PhoneNumber, Residence, FieldOfExpertise, Education, 
                                WorkExperience, DesiredFunction, 
                                JobApplicationReason, DesiredLocation) VALUES (@Gender, @FirstName,
                                @LastName, @Email, @PhoneNumber, @Residence, @FieldOfExpertise, @Education,
                                @WorkExperience, @DesiredFunction, @JobApplicationReason, @DesiredLocation)";
            await Task.FromResult(_cloudDataAccess.SaveData(sql, request.model, connectionString));
            return request.model;
        }
    }
}
