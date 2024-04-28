using ClinicManager.Application.Commands.Patient;
using ClinicManager.Application.Queries.Patient;
using ClinicManager.Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Post")] 
        public async Task<IActionResult> Post([FromBody] CreatePatientCommand command)
        {
            var response = await _mediator.Send(command);

            if (!response.IsSuccess)
                return StatusCode(500, response.Message);

            return StatusCode(201, response);
        }

        [HttpGet("GetByPhoneNumber")]
        [Authorize(Roles = nameof(ERoleEnum.Patient))]
        public async Task<IActionResult> GetByPhoneNumber(string phoneNumber)
        {
            var query = new GetPatientByPhoneNumberQuery(phoneNumber);
            var response = await _mediator.Send(query);

            if (!response.IsSuccess)
                return StatusCode(500, response.Message);

            return StatusCode(200, response);
        }

        [HttpGet("GetByCpf")]
        [Authorize(Roles = nameof(ERoleEnum.Patient))]
        public async Task<IActionResult> GetByCpf(string cpf)
        { 

            var query = new GetPatientByCpfQuery(cpf);

            var response = await _mediator.Send(query);

            if (!response.IsSuccess)
                return StatusCode(500, response.Message);

            return StatusCode(200, response);
        }

        [HttpDelete("Delete")]
        [Authorize(Roles = nameof(ERoleEnum.Patient))]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeletePatientCommand(id);

            var response = await _mediator.Send(command);

            if (!response.IsSuccess)
                return StatusCode(500, response.Message);

            return StatusCode(200, response);
        }

        [HttpPut("Update")]
        [Authorize(Roles = nameof(ERoleEnum.Patient))]
        public async Task<IActionResult> Update(UpdatePatientCommand command)
        {
            var response = await _mediator.Send(command);

            if (!response.IsSuccess)
                return StatusCode(500, response.Message);

            return StatusCode(200, response);
        }
    }
}
