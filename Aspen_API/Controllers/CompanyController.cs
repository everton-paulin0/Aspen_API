using Aspen_API.Entities;
using Aspen_API.Models;
using Aspen_API.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aspen_API.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly AspenDbContext _context;
        public CompanyController( AspenDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Post(CreateCompanyInputModel model)
        {
            var company = model.ToEntity();

            _context.Companies.Add(company);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
        }

        [HttpGet]
        public IActionResult GetAll(string search)
        {
            var companies = _context.Companies.Where(c => !c.IsDeleted).ToList();

            var model = companies.Select(CompanyItemModel.FromEntity).ToList();

            return Ok(companies);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var company = _context.Companies.SingleOrDefault(c => c.Id == id);

            var model = CompanyViewModel.FromEntity(company);

            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateCompanyInputModel model)
        {
            var company = _context.Companies.SingleOrDefault(c => c.Id == id);

            if(company == null)
            {
                return NotFound();
            }

            company.Update(model.CompanyName, model.CompanyDocNumber, model.CompanyAddress, model.CompanyCity, model.CompanyState, model.CompanyZipCode, model.CompanyEmail, model.IdUser, model.IdContactPerson);

            _context.Companies.Update(company);

            _context.SaveChanges();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var company = _context.Companies.SingleOrDefault(c => c.Id == id);

            if (company == null)
            {
                return NotFound();
            }

            company.SetAsDeleted();
            _context.Companies.Update(company);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, CreateCompanyCommentInputModel model)
        {
            var company = _context.Companies.SingleOrDefault(c => c.Id == id);

            if (company == null)
            {
                return NotFound();
            }

            var comment = new CompanyComment(model.Content, model.IdUser, model.IdCompany);

            _context.CompanyComments.Add(comment);
            _context.SaveChanges();


            return Ok();
        }
    }
}
