using System.Net.Http;
using NUnit.Framework;

namespace Usol.Wally.WebApi.Tests
{
    public class TestBase
    {
        private APIWebApplicationFactory _factory;
        protected HttpClient _client;

        [OneTimeSetUp]
        public void GivenARequestToTheController()
        {
            _factory = new APIWebApplicationFactory();
            _client  = _factory.CreateClient();
        }
    }
}