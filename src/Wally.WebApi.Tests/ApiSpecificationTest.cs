using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Usol.Wally.WebApi.Tests
{
    /// <summary>
    /// Check if route a) exists and b) requires auth
    /// </summary>
    [TestFixture]
    public class ApiSpecificationTest : TestBase
    {
        [TestCase("/api/Account/List")]
        [TestCase("/api/Account/ListWithRests")]
        [TestCase("/api/Account/QuickSearch")]
        [TestCase("/api/Account/Index")]
        [TestCase("/api/Account/Create")]
        [TestCase("/api/Account/Update")]
        [TestCase("/api/Account/Merge")]
        [TestCase("/api/Category/List")]
        [TestCase("/api/Category/Details")]
        [TestCase("/api/Category/Create")]
        [TestCase("/api/Category/Update")]
        [TestCase("/api/Currency/List")]
        [TestCase("/api/Report/NonCategorizedTransactions")]
        [TestCase("/api/Report/CrookedCategorizedTransactions")]
        [TestCase("/api/Report/StatByMonths")]
        [TestCase("/api/Report/StatByWeeks")]
        [TestCase("/api/Report/SpendingByCategories")]
        [TestCase("/api/TransactionCategory/Detail")]
        [TestCase("/api/TransactionCategory/Create")]
        [TestCase("/api/TransactionCategory/Update")]
        [TestCase("/api/TransactionCategory/Delete")]
        [TestCase("/api/Transaction/List")]
        [TestCase("/api/Transaction/Detail")]
        [TestCase("/api/Transaction/Create")]
        [TestCase("/api/Transaction/Update")]
        [TestCase("/api/Transaction/Delete")]
        [TestCase("/api/User/List")]
        public async Task Route_ExistsAndForbides_Unauthorized(string uri)
        {
            var client = NotAuthorizedClient();
            var response = await client.PostAsync(uri, null);

            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}