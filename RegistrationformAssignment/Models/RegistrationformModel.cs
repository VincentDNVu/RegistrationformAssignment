using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace RegistrationformAssignment.RegistrationformEnums
{
    public enum Gender { Man, Vrouw }
    public enum FieldOfExpertise { Office, Techniek, Horeca, Onbekend }
    public enum DesiredLocation { Zwaag, Heerhugowaard }
    public enum JobApplicationReason { Werkzoekend, Uitdaging, Werkdruk, Locatie, Onbekend }
}

namespace RegistrationformAssignment.Models
{
    public class RegistrationformModel
    {
        public int Id { get; set; }
        [Required, EnumDataType(typeof(RegistrationformEnums.Gender))]
        public string Gender { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string Residence { get; set; }
        public string FieldOfExpertise { get; set; }
        public string Education { get; set; }
        public string WorkExperience { get; set; }
        [Required]
        public string DesiredFunction { get; set; }
        [Required]
        public string JobApplicationReason { get; set; }
        [Required]
        public string DesiredLocation { get; set; }
        public string FormComments { get; set; }
    }
}
