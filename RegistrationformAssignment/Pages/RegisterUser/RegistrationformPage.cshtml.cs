using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RegistrationformAssignment.Commands;
using RegistrationformAssignment.Models;

namespace RegistrationformAssignment.Pages
{
    public class RegistrationformPageModel : PageModel
    {
        [BindProperty]
        public RegistrationformModel Registrationform { get; set; }

        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public RegistrationformPageModel(ILogger<RegistrationformPageModel> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                                .Where(y => y.Count > 0)
                                .ToList();

                _logger.LogInformation($"{errors.ToString()} have been found please check the errors in the model");
                return Page();
            }
            foreach (PropertyInfo prop in Registrationform.GetType().GetProperties())
              {
                  //Using reflection to log the data that's being posted, in case something goes wrong
                  _logger.LogInformation($"Registrationform OnPost prop: {prop} value: {prop?.GetValue(Registrationform, null)?.ToString()}");
              }
            await _mediator.Send(new AddRegistrationformCommand(Registrationform));
            return RedirectToPage("/Home/Index");
        }
    }
}
