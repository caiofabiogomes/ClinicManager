using ClinicManager.Application.Commands.MedicalAppointment;
using ClinicManager.Application.Queries.MedicalAppointment;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/[controller]")]
    public class MedicalAppointmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MedicalAppointmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] CreateMedicalAppointmentCommand command)
        {
            var response = await _mediator.Send(command);

            if (!response.IsSuccess)
                return StatusCode(500, response.Message);

            return StatusCode(201, response);
        }

        [HttpGet("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll(GetAllMedicalAppointmentsQuery query) 
        {
            var response = await _mediator.Send(query);

            if (!response.IsSuccess)
                return StatusCode(500, response.Message);

            return StatusCode(200, response);
        }

        [HttpGet("GetById")]
        [Authorize]
        public async Task<IActionResult> GetById(Guid id) 
        {
            var query = new GetMedicAppointmentByIdQuery(id);

            var response = await _mediator.Send(query);

            if(!response.IsSuccess)
                return StatusCode(500, response.Message);

            return StatusCode(200, response);
        }

        [HttpDelete("Delete")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteMedicalAppointmentCommand(id); 

            var response = await _mediator.Send(command);

            if (!response.IsSuccess)
                return StatusCode(500, response.Message);

            return StatusCode(200, response);
        }

        [HttpPut("Update")]
        [Authorize]
        public async Task<IActionResult> Update(UpdateMedicalAppointmentCommand command) 
        {
            var response = await _mediator.Send(command);

            if (!response.IsSuccess)
                return StatusCode(500, response.Message);

            return StatusCode(200, response);
        }
    }
}
