using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Usol.Wally.Domain.Models;
using Usol.Wally.Persistence;

namespace Usol.Wally.Application.Tests.Accounts
{
    public class AccountsTestBase : TestBase
    {
        protected async Task<Application.Accounts.Create.AccountData> Create(Application.Accounts.Create.AccountData request)
        {
            using (var context = new ApplicationDbContext(this.GetDbOptions()))
            {
                var command = new Application.Accounts.Create.Command(request);
                var handler = new Application.Accounts.Create.Handler(context);
                return await handler.Handle(command, this.GetCancellationToken());
            }
        }

        protected async Task<Account> GetById(int id)
        {
            using (var context = new ApplicationDbContext(GetDbOptions()))
            {
                var account = await context.Accounts.SingleOrDefaultAsync(x => x.Id == id, GetCancellationToken());
                return account;
            }
        }
    }
}