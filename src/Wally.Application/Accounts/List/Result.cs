using System.Collections.Generic;

namespace Usol.Wally.Application.Accounts.List
{
    public class Result
    {
        public Result(IEnumerable<AccountDto> accounts, int totalElements)
        {
            this.Accounts = accounts;
            this.TotalElements = totalElements;
        }

        public IEnumerable<AccountDto> Accounts { get; }

        public int TotalElements { get; }
    }
}