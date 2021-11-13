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
    public async Task<IActionResult> Register([FromBody]RegisterRequest request)
    {
            return Ok("hello");

            try
            {

            var provider = new AmazonCognitoIdentityProviderClient();

                var userPool = new CognitoUserPool(config.Value.UserPoolId, config.Value.ClientId, provider);

                await userPool.SignUpAsync(request.Email, request.Password, new Dictionary<string, string>
                {
                    ["name"] = request.Name
                }, new Dictionary<string,string>());
                
                return Ok("Completed");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, e.Message);
            }
    }
  }

  /*
  Auth__Region = data.aws_region.current.name
      Auth__ClientId = aws_cognito_user_pool_client.main.id
      Auth__ClientSecret = aws_cognito_user_pool_client.main.client_secret
      Auth__UserPoolId = aws_cognito_user_pool.main.id
      Auth__Domain
  
  */

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