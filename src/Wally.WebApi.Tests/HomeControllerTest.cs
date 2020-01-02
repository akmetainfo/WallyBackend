using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Usol.Wally.WebApi.Tests
{
    [TestFixture]
    public class HomeControllerTest : TestBase
    {
        [Test]
        public async Task ControllerHasNoIndexPage()
        {
            var response = await _client.GetAsync("/");

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}