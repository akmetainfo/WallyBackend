using System.Collections.Generic;

namespace Usol.Wally.Application.Transactions.List
{
    public class Result
    {
        public Result(IEnumerable<TransactionDto> transactions, int totalElements)
        {
            this.Transactions = transactions;
            this.TotalElements = totalElements;
        }

        public IEnumerable<TransactionDto> Transactions { get; set; }

        public int TotalElements { get; set; }
    }
}