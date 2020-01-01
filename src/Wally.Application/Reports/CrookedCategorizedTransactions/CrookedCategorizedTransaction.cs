using System;

namespace Usol.Wally.Application.Reports.CrookedCategorizedTransactions
{
    public class CrookedCategorizedTransaction
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public decimal Amount { get; set; }
    }
}