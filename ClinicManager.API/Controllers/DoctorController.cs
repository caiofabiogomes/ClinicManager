using ClinicManager.Application.Commands.Doctor;
using ClinicManager.Application.Queries.Doctor;
using ClinicManager.Core.Enums;
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

            return StatusCode(201, response);
        }

        [HttpGet("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll(GetAllDoctorsQuery query)
        {
            var response = await _mediator.Send(query);

            if (!response.IsSuccess)
                return StatusCode(500, response.Message);

            return StatusCode(201, response);
        }
        [HttpGet("GetById")]
        [Authorize]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetDoctorByIdQuery(id);

            var response = await _mediator.Send(query);

            if (!response.IsSuccess)
                return StatusCode(500, response.Message);

            return StatusCode(201, response);
        }

        [HttpDelete("Delete")]
        [Authorize(Roles = nameof(ERoleEnum.Doctor))]
        public async Task<IActionResult> Delete(DeleteDoctorCommand command)
        {
            var response = await _mediator.Send(command);

            if (!response.IsSuccess)
                return StatusCode(500, response.Message);

            return StatusCode(201, response);
        }

        [HttpPut("Update")]
        [Authorize(Roles = nameof(ERoleEnum.Doctor))]
        public async Task<IActionResult> Update(UpdateDoctorCommand command)
        {
            var response = await _mediator.Send(command);

            if (!response.IsSuccess)
                return StatusCode(500, response.Message);

            return StatusCode(201, response);
        }
    }
}
