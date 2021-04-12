using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.FluentMap.Mapping;
using RegistrationformAssignment.Models;

namespace RegistrationformAssignment.Mapping
{
    public class RegistrationformMapping : EntityMap<RegistrationformModel>
    {
        public RegistrationformMapping()
        {
            Map(r => r.Id).ToColumn("Id");
            Map(r => r.FirstName).ToColumn("firstname");
            Map(r => r.LastName).ToColumn("lastname");
            Map(r => r.Email).ToColumn("email");
            Map(r => r.PhoneNumber).ToColumn("phonenumber");
            Map(r => r.Residence).ToColumn("residence");
            Map(r => r.FieldOfExpertise).ToColumn("fieldofexpertise");
            Map(r => r.Education).ToColumn("education");
            Map(r => r.WorkExperience).ToColumn("workexperience");
            Map(r => r.DesiredFunction).ToColumn("desiredfunction");
            Map(r => r.JobApplicationReason).ToColumn("jobapplicationreason");
            Map(r => r.DesiredLocation).ToColumn("desiredlocation");
            Map(r => r.FormComments).ToColumn("formcomments");
        }
    }
}
