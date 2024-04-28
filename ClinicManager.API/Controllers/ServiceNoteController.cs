using ClinicManager.Application.Commands.ServiceNote;
using ClinicManager.Application.Queries.ServiceNote;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/[controller]")]
    public class ServiceNoteController : ControllerBase
    { 
        private readonly IMediator _mediator;

        public ServiceNoteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Post")]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] CreateServiceNoteCommand command)
        {
            var response = await _mediator.Send(command);

            if (!response.IsSuccess)
                return StatusCode(500, response.Message);

            return StatusCode(201, response);
        }

        [HttpGet("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll(GetAllServiceNotesQuery query)
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
            var query = new GetServiceNoteByIdQuery(id);

            var response = await _mediator.Send(query);

            if (!response.IsSuccess)
                return StatusCode(500, response.Message);

            return StatusCode(200, response);
        }

        [HttpDelete("Delete")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteServiceNoteCommand(id);

            var response = await _mediator.Send(command);

            if (!response.IsSuccess)
                return StatusCode(500, response.Message);

            return StatusCode(200, response);
        }

        [HttpPut("Update")]
        [Authorize]
        public async Task<IActionResult> Update(UpdateServiceNoteCommand command)
        {
            var response = await _mediator.Send(command);

            if (!response.IsSuccess)
                return StatusCode(500, response.Message);

            return StatusCode(200, response);
        }
    }
}
