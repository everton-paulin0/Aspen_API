using Aspen_API.Entities;
using Aspen_API.Models;
using Aspen_API.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aspen_API.Controllers
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
