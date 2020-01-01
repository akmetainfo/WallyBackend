using MediatR;

namespace Usol.Wally.Application.Accounts.Update
{
    public class Command : IRequest<AccountData>
    {
        public Command(AccountData account)
        {
            this.Account = account;
        }

        public AccountData Account { get; }
    }
}