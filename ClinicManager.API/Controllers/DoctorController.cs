using ClinicManager.Application.Commands.Doctor;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DoctorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Post")] 
        public async Task<IActionResult> Post([FromBody] CreateDoctorCommand command)
        {
            var response = await _mediator.Send(command);

            if (!response.IsSuccess)
                return StatusCode(500, response.Message);

            return StatusCode(201, response.Message);
        }
    }
}
