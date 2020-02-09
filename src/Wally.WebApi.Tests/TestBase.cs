using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Usol.Wally.WebApi.Tests
{
    public class TestBase
    {
        private APIWebApplicationFactory _factory;
        private HttpClient _client;

        [OneTimeSetUp]
        public void GivenARequestToTheController()
        {
            _factory = new APIWebApplicationFactory();
            _client = _factory.CreateClient();
        }

        protected HttpClient NotAuthorizedClient()
        {
            var client = this._client;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "invalid_token");
            return client;
        }

        protected HttpClient AuthorizedClient()
        {
            var client = this._client;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetValidToken());
            return client;
        }

        private static string GetValidToken()
        {
            //var claims = new[]
            //{
            //    new Claim(ClaimTypes.NameIdentifier, "ExistingUser_Id"),
            //    new Claim(ClaimTypes.Name,           "ExistingUser_Username"),
            //};
            var claims = Enumerable.Empty<Claim>();

            return new TokenGenerator().Generate(DateTime.UtcNow, claims);
        }

        protected static StringContent ToContent(object request)
        {
            var jsonString = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            return content;
        }
    }
}