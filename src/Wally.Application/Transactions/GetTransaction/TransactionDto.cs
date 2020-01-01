using System;

namespace Usol.Wally.Application.Transactions.GetTransaction
{
    public class TransactionDto
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public decimal AmountSource { get; set; }

        public decimal AmountDestination { get; set; }

        public bool Checked { get; set; }

        public string Comment { get; set; }
    }
}