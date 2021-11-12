using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Bookworm.Xapi.Controllers
{
  [ApiController]
  [Route("users")]
  public class UsersController : ControllerBase
  {
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody]RegisterRequest request)
    {
      return Ok(new {
        ClientId = Environment.GetEnvironmentVariable("Auth__ClientId")
      });
    }
  }

  public class RegisterRequest
  {
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
  }
}