using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Usol.Wally.WebApi
{
    [TestFixture]
    public class HomeControllerTest : TestBase
    {
        [Test]
        public async Task ControllerHasNoIndexPage()
        {
            var client = NotAuthorizedClient();
            var response = await client.GetAsync("/");

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}