using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RegistrationformAssignment.Models;
using RegistrationformAssignment.Queries;

namespace RegistrationformAssignment.Pages
{
    public class FormApplicationsModel : PageModel
    {
        private readonly IMediator _mediator;
        public FormApplicationsModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public List<RegistrationformModel> Registrationforms { get; set; }

        public async Task OnGet()
        {
            Registrationforms = await _mediator.Send(new GetAllRegistrationformsQuery()); ;
        }
    }
}
