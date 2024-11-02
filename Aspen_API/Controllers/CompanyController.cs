using Application.Models;
using Aspen.Application.Commands.DeleteCompany;
using Aspen.Application.Commands.InsertComments;
using Aspen.Application.Commands.InsertCompany;
using Aspen.Application.Commands.UpdateCompany;
using Aspen.Application.Queries.GetAllCompany;
using Aspen.Application.Queries.GetByIdCompany;
using Aspen.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Infrastructure.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        
        private readonly ICompanyService _service;
        private readonly IMediator _mediator;
        public CompanyController(ICompanyService service, IMediator mediator)
        {
            _service = service;
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Post(InsertCompanyCommand command)
        {
            var result = await _mediator.Send(command);

            if(!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string search = "")
        {
           var query = new GetAllCompaniesQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetCompanyByIdQuery(id));

            if (!result.IsSucess) 
            {
                return BadRequest(result.Message);
            
            }
                return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateCompanyCommand command)
        {
            var result = await _mediator.Send(command);

            if(!result.IsSucess)
            {
                return BadRequest(result);
            }

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var result = await _mediator.Send(new DeleteCompanyCommand(id));

            if (!result.IsSucess)
            {
                return BadRequest(result);
            }

            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment(int id, InsertCommentCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSucess)
            {
                return BadRequest(result);
            }

            return NoContent();
            
        }
    }
}
