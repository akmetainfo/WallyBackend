using System.Collections.Generic;

namespace Usol.Wally.Application.Reports.NonCategorizedTransactions
{
    public class Result
    {
        public Result(IEnumerable<NonCategorizedTransaction> transactions)
        {
            this.Transactions = transactions;
        }

        public IEnumerable<NonCategorizedTransaction> Transactions { get; }
    }
}
