using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using Usol.Wally.WebApi.Controllers;

namespace Usol.Wally.WebApi
{
    [TestFixture]
    public class AuthControllerTest : TestBase
    {
        [Test]
        public async Task InvalidUser_ReturnBadRequest()
        {
            var request = new AuthController.TokenRequest
            {
                UserName = "invalid-user-login",
                Password = "password-here",
            };

            var client = NotAuthorizedClient();
            var response = await client.PostAsync("/api/token", ToContent(request));

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}