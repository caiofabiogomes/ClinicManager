﻿using ClinicManager.Application.Commands.ServiceNote;
using ClinicManager.Application.Queries.ServiceNote;
using MediatR;
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
        public async Task<IActionResult> Post([FromBody] CreateServiceNoteCommand command)
        {
            var response = await _mediator.Send(command);

            if (!response.IsSuccess)
                return StatusCode(500, response.Message);

            return StatusCode(201, response);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(GetAllServiceNotesQuery query)
        {
            var response = await _mediator.Send(query);

            if (!response.IsSuccess)
                return StatusCode(500, response.Message);

            return StatusCode(200, response);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(GetServiceNoteByIdQuery query)
        {
            var response = await _mediator.Send(query);

            if (!response.IsSuccess)
                return StatusCode(500, response.Message);

            return StatusCode(200, response);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(DeleteServiceNoteCommand command)
        {
            var response = await _mediator.Send(command);

            if (!response.IsSuccess)
                return StatusCode(500, response.Message);

            return StatusCode(200, response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateServiceNoteCommand command)
        {
            var response = await _mediator.Send(command);

            if (!response.IsSuccess)
                return StatusCode(500, response.Message);

            return StatusCode(200, response);
        }
    }
}
