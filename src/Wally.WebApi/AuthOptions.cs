using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Usol.Wally.WebApi
{
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer";

        public const string AUDIENCE = "https://localhost:44345/";

        private const string KEY = "mysupersecret_secretkey!123";

        public const int LIFETIME = 180;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}