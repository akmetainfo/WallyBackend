using System.Threading.Tasks;
using NUnit.Framework;

namespace Usol.Wally.Application.Tests.Accounts.Get
{
    [TestFixture]
    public class Test : AccountsTestBase
    {
        [Test]
        public async Task EmptyDatabase()
        {
            var account = await GetById(0);

            Assert.IsNull(account);
        }

        [Test]
        public async Task NonExistingEntity_ReturnsNull()
        {
            var request = GetAccountData();

            await Create(request);

            var account = await GetById(0);

            Assert.IsNull(account);
        }

        [Test]
        public async Task ExistingEntity_ReturnsData()
        {
            var request = GetAccountData();

            await Create(request);

            var account = await GetById(1);

            Assert.IsNotNull(account);
            Assert.AreEqual(request.Title, account.Title);
            Assert.AreEqual(request.Notes, account.Notes);
            Assert.AreEqual(request.CurrencyId, account.CurrencyId);
            Assert.AreEqual(request.IsActive, account.IsActive);
            Assert.AreEqual(request.IsCorrespondent, account.IsCorrespondent);
        }

        private static Application.Accounts.Create.AccountData GetAccountData()
        {
            return new Application.Accounts.Create.AccountData(0, "tt", "asdf", false, true, 643);
        }
    }
}