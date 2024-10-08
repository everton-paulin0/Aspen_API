using Aspen_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aspen_API.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(CreateCompanyInputModel model)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
        }

        [HttpGet]
        public IActionResult GetAll(string search)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateCompanyInputModel model)
        {
            //model.IdCompany = id;
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            return Ok();
        }

        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, CreateCompanyCommentInputModel model)
        {
            return Ok();
        }
    }
}
