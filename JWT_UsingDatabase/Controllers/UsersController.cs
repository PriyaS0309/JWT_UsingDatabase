using JWT_UsingDatabase.Models;
using JWT_UsingDatabase.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace JWT_NEW.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IJWTManagerRepo JWTManagerRepo;
        public UsersController(IJWTManagerRepo jWTManagerRepo)
        {
            this.JWTManagerRepo = jWTManagerRepo;
        }

        
        [HttpGet]
        [Route("userlist")]
        public List<string> Get()
        {
            var users = new List<string>
            {
              "Priya",
                "Shweta"
            };
            return users;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(Users userdata)
        {
            var token = JWTManagerRepo.Authenticate(userdata);

            if (token == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(token);
            }
        }
    }
}