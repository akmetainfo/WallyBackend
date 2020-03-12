using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Usol.Wally.Domain.Models;
using Usol.Wally.Persistence;

namespace Usol.Wally.Application.Accounts
{
    public class AccountsTestBase : TestBase
    {
        protected async Task<Create.AccountData> Create(Create.AccountData request)
        {
            using (var context = new ApplicationDbContext(this.GetDbOptions()))
            {
                var command = new Create.Command(request);
                var handler = new Create.Handler(context);
                return await handler.Handle(command, this.GetCancellationToken());
            }
        }

        protected async Task<Account> GetById(int id)
        {
            using (var context = new ApplicationDbContext(this.GetDbOptions()))
            {
                var account = await context.Accounts.SingleOrDefaultAsync(x => x.Id == id, this.GetCancellationToken());
                return account;
            }
        }
    }
}