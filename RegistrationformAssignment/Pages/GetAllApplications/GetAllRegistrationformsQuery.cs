using MediatR;
using RegistrationformAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RegistrationformAssignment.Queries
{
    public record GetAllRegistrationformsQuery() : IRequest<List<RegistrationformModel>>;
   
}
