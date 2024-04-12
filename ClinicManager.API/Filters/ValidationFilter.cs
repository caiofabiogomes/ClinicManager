using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using ClinicManager.Application.Abstractions;

namespace ClinicManager.API.Filters
{
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var messages = context.ModelState
                    .SelectMany(entry => entry.Value.Errors.Select(error => new ValidationError(entry.Key, error.ErrorMessage)))
                    .ToList();

                context.Result = new BadRequestObjectResult(messages);
            }
        }
    }
}
