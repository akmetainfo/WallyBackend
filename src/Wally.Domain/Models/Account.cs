using System.Collections.Generic;

namespace Usol.Wally.Domain.Models
{
    public class Account
    {
        public const int TitleMaxLength = 50;
        public const int NotesMaxLength = 50;

        public int Id { get; set; }

        public string Title { get; set; }

        public string Notes { get; set; }

        public bool IsActive { get; set; }

        public bool IsCorrespondent { get; set; }

        public int CurrencyId { get; set; }

        public Currency Currency { get; set; }

        public virtual IEnumerable<Transaction> SourceTransactions { get; set; }

        public virtual IEnumerable<Transaction> DestinationTransactions { get; set; }
    }
}