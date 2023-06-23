using Microsoft.AspNetCore.Mvc;
using ProjectAPI.Application.Services;
using ProjectAPI.Domain.Entities;

namespace ProjectAPI.Api.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            if(username == "admin" && password == "admin")
            {
                var token = TokenService.GenerateToken(new Product());
                return Ok(token);
            }

            return BadRequest("username or password invalid");
        }
    }
}
