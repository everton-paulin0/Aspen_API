using Application.Models;
using Core.Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AspenDbContext _context;
        public UserController(AspenDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Post (CreateUserInputModel model)
        {
            var user = new User(model.FullName, model.Email, model.BirthDate, model.MobilePhone, model.IdCompany);

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _context.Users.ToList();

            if (user is null)
            {
                return NotFound();
            }

            return NoContent();
        }    

    }
}
