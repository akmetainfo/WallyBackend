using System.Collections.Generic;

namespace Usol.Wally.Application.Reports.CrookedCategorizedTransactions
{
    public class Result
    {
        public Result(IEnumerable<CrookedCategorizedTransaction> transactions)
        {
            this.Transactions = transactions;
        }

        public IEnumerable<CrookedCategorizedTransaction> Transactions { get; }
    }
}
