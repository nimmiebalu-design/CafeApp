using Azure.Core;
using CafeApp.Application.Commands;
using CafeApp.Application.Commands.AddCafe;
using CafeApp.Application.Commands.DeleteCafe;
using CafeApp.Application.Commands.UpdateCafe;
using CafeApp.Application.Queries.GetCafes;
using CafeApp.Application.Queries.GetEmployees;
using CafeApp.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CafeApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CafesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CafesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Cafe")]
        public async Task<IActionResult> AddCafeAsync([FromBody] AddCafeDto cafedto)
        {
            // This method should add a new cafe
            // Implementation goes here
            if (cafedto == null)
            {
                return BadRequest("Cafe data is required.");
            }

            if (string.IsNullOrWhiteSpace(cafedto.name))
            {
                return BadRequest("Cafe name is required.");
            }
            if (string.IsNullOrWhiteSpace(cafedto.description))
            {
                return BadRequest("Description is required.");
            }
            if (string.IsNullOrWhiteSpace(cafedto.location))
            {
                return BadRequest("Location is required.");
            }

            var result = await _mediator.Send(new AddCafeCommand(cafedto));

            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetCafesAsync([FromQuery] string? location=null)
        {
            // This method should return a list of cafes
            // Implementation goes here
            var employees = await _mediator.Send(new GetCafesQuery(location));

            return Ok(employees);
        }
       
        [HttpDelete]
        public async Task<IActionResult> DeleteCafeAsync([FromQuery] Guid cafeid)
        {
            // This method should delete a cafe by ID
            // Implementation goes here
            if (cafeid == Guid.Empty)
            {
                {
                    return BadRequest("Cafe ID is required.");
                }
            }
            if (cafeid != Guid.Empty)
            {
                var result = await _mediator.Send(new DeleteCafeCommand(cafeid));

                if (!result)
                {
                    return NotFound("Cafe not found.");
                }
            }
            else
            {
                return BadRequest("Invalid Cafe ID");
            }
                return Ok($"Cafe with ID: {cafeid} deleted successfully.");
        }

      
        [HttpPut("Cafe")]
        public async Task<IActionResult> UpdateCafeAsync([FromBody] UpdateCafeDto cafedto)
        {
            // This method should update an existing cafe
            // Implementation goes here
            if (cafedto.id == Guid.Empty)
            {
                return BadRequest("Cafe ID is required.");
            }
            if (cafedto == null)
            {
                return BadRequest("Cafe data is required.");
            }
            
            if (string.IsNullOrWhiteSpace(cafedto.name))
            {
                return BadRequest("Cafe name is required.");
            }
            if(string.IsNullOrWhiteSpace(cafedto.description))
            {
                return BadRequest("Description is required.");
            }
                if (string.IsNullOrWhiteSpace(cafedto.location))
            {
                return BadRequest("Location is required.");
            }
            
            var result = await _mediator.Send(new UpdateCafeCommand(cafedto));
            
            return Ok(result);
        }

    }
}
