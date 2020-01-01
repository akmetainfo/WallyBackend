using System;

namespace Usol.Wally.Application.Reports.NonCategorizedTransactions
{
    public class NonCategorizedTransaction
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public decimal Amount { get; set; }
    }
}