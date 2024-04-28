using ClinicManager.Application.Commands.Login;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var loginUserviewModel = await _mediator.Send(command);

            if (!loginUserviewModel.IsFound)
                return BadRequest("Email or password incorrects!");

            return Ok(loginUserviewModel); 
        }
    }
}
