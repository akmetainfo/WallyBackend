using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using Usol.Wally.WebApi.Controllers;

namespace Usol.Wally.WebApi.Tests
{
    [TestFixture]
    public class AuthControllerTest : TestBase
    {
        [Test]
        public async Task InvalidUser_ReturnBadRequest()
        {
            var request = ComposeRequest("invalid-user-login", "password-here");

            var response = await _client.PostAsync("/api/token", request);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        private static StringContent ComposeRequest(string username, string password)
        {
            var data = new AuthController.TokenRequest { UserName = username, Password = password };
            var jsonString = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            return content;
        }
    }
}