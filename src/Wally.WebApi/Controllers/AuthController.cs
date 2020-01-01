using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Usol.Wally.WebApi.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> UserManager;
        private readonly SignInManager<IdentityUser> SignInManager;

        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.UserManager = userManager;
            this.SignInManager = signInManager;
        }

        [HttpPost("/api/token")]
        public async Task Token([FromBody] TokenRequest tokenRequest)
        {
            var principal = await this.GetIdentity(tokenRequest);

            if (principal == null)
            {
                this.Response.StatusCode = 400;
                await this.WriteResponse("Invalid username or password.");
                return;
            }

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                AuthOptions.ISSUER,
                AuthOptions.AUDIENCE,
                principal.Claims,
                now,
                now.Add(TimeSpan.FromHours(AuthOptions.LIFETIME)),
                new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                token = encodedJwt,
                username = principal.Identity.Name,
            };

            await this.WriteResponse(response);
        }

        private async Task WriteResponse(object response)
        {
            this.Response.ContentType = "application/json";
            await this.Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }

        private async Task<ClaimsPrincipal> GetIdentity(TokenRequest tokenRequest)
        {
            var user = await this.UserManager.FindByNameAsync(tokenRequest.UserName);
            if (user != null)
            {
                var check = await this.UserManager.CheckPasswordAsync(user, tokenRequest.Password);
                if (check)
                {
                    var principal = await this.SignInManager.CreateUserPrincipalAsync(user);
                    return principal;
                }
            }
            return null;
        }

        public class TokenRequest
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    }
}