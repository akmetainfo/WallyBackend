using System.Threading.Tasks;
using NUnit.Framework;

namespace Usol.Wally.Application.Accounts.Create
{
    /// <summary>
    /// Tests for <see cref="Handler"/>
    /// </summary>
    public class HandlerTest : AccountsTestBase
    {
        [Test]
        public async Task Handle_ReturnSavedToDbData()
        {
            var request = GetAccountData();

            var result = await this.Create(request);

            Assert.AreNotEqual(0, result.Id);
            Assert.AreEqual(result.Title, request.Title);
            Assert.AreEqual(result.Notes, request.Notes);
            Assert.AreEqual(result.CurrencyId, request.CurrencyId);
            Assert.AreEqual(result.IsActive, request.IsActive);
            Assert.AreEqual(result.IsCorrespondent, request.IsCorrespondent);
        }

        private static AccountData GetAccountData()
        {
            return new AccountData(0, "tt", "asdf", false, true, 643);
        }
    }
}