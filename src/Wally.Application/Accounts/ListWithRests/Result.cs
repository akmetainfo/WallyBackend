using System.Collections.Generic;

namespace Usol.Wally.Application.Accounts.ListWithRests
{
    public class Result
    {
        public Result(IEnumerable<AccountDto> accounts)
        {
            this.Accounts = accounts;
        }

        public IEnumerable<AccountDto> Accounts { get; }
    }
}