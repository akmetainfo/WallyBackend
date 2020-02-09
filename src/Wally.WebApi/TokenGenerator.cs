using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Usol.Wally.WebApi
{
    public class TokenGenerator
    {
        public string Generate(DateTime now, IEnumerable<Claim> claims)
        {
            var token = Emit(now, claims);
            var encoded = Encode(token);
            return encoded;
        }

        private static JwtSecurityToken Emit(DateTime now, IEnumerable<Claim> claims)
        {
            return new JwtSecurityToken(
                AuthOptions.ISSUER,
                AuthOptions.AUDIENCE,
                claims,
                now,
                now.Add(TimeSpan.FromHours(AuthOptions.LIFETIME)),
                new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
        }

        private static string Encode(JwtSecurityToken token)
        {
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}