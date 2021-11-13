using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Amazon.Extensions.CognitoAuthentication;
using Amazon.Runtime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Bookworm.Xapi.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IOptions<UserPoolConfig> config;

        public UsersController(IOptions<UserPoolConfig> config)
        {
            this.config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register()
        {
            return Ok(config.Value);
        }
    }

    public class UserPoolConfig
    {
        public string Region { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string UserPoolId { get; set; }
        public string Domain { get; set; }
    }

    public class RegisterRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
