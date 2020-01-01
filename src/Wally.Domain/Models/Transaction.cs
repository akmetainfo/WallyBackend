using System;
using System.Collections.Generic;

namespace Usol.Wally.Domain.Models
{
    public class Transaction
    {
        public const int CommentMaxLength = 150;

        public int Id { get; set; }

        public DateTime Created { get; set; }

        public decimal AmountSource { get; set; }

        public decimal AmountDestination { get; set; }

        public int SourceId { get; set; }

        public Account Source { get; set; }

        public int DestinationId { get; set; }

        public Account Destination { get; set; }

        public bool Checked { get; set; }

        public string Comment { get; set; }

        public virtual IEnumerable<TransactionCategory> TransactionCategories { get; set; }
    }
}