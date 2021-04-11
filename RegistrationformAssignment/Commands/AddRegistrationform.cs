using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RegistrationformAssignment.Models;

namespace RegistrationformAssignment.Commands
{
    public record AddRegistrationformCommand(RegistrationformModel model) : IRequest<RegistrationformModel>;
}
