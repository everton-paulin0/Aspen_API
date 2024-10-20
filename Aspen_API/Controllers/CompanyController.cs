using Application.Models;
using Aspen.Application.Services.Interfaces;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;


namespace Infrastructure.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly AspenDbContext _context;
        private readonly ICompanyService _service;
        public CompanyController( AspenDbContext context, ICompanyService service)
        {
            _context = context;
            _service = service;
        }
        [HttpPost]
        public IActionResult Post(CreateCompanyInputModel model)
        {
            var result = _service.Insert(model);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);
        }

        [HttpGet]
        public IActionResult GetAll(string search = "")
        {
            var result = _service.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);
            if (!result.IsSucess) 
            {
                return BadRequest(result.Message);
            
            }
                return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateCompanyInputModel model)
        {
            var result = _service.Update(model);

            if(!result.IsSucess)
            {
                return BadRequest(result);
            }

            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var result = _service.Delete(id);

            if (!result.IsSucess)
            {
                return BadRequest(result);
            }

            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, CreateCompanyCommentInputModel model)
        {
            var result = _service.InsertComments(id, model);

            if (!result.IsSucess)
            {
                return BadRequest(result);
            }

            return NoContent();
            
        }
    }
}
