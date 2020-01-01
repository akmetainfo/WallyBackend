using System.Collections.Generic;

namespace Usol.Wally.Application.Transactions.GetTransaction
{
    public class Result
    {
        public TransactionDto Transaction { get; set; }

        public AccountDto Source { get; set; }

        public AccountDto Destination { get; set; }

        public virtual IEnumerable<TransactionCategoryDto> Categories { get; set; }
    }
}