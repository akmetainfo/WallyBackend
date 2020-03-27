using System.Collections.Generic;
using Usol.Wally.Domain.Extensions;

namespace Usol.Wally.Domain.Models
{
    public class Account
    {
        public const int TitleMaxLength = 50;

        public const int NotesMaxLength = 50;

        private string _title;

        private string _notes;

        public Account()
        {
            this.SourceTransactions = new List<Transaction>();
            this.DestinationTransactions = new List<Transaction>();
        }

        public Account(int id, string title, string notes, bool isActive, bool isCorrespondent, int currencyId, Currency currency, ICollection<Transaction> sourceTransactions, ICollection<Transaction> destinationTransactions)
        {
            this.Id = id;
            this.Title = title;
            this.Notes = notes;
            this.IsActive = isActive;
            this.IsCorrespondent = isCorrespondent;
            this.CurrencyId = currencyId;
            this.Currency = currency;
            this.SourceTransactions = sourceTransactions;
            this.DestinationTransactions = destinationTransactions;
        }

        public Account(int id, string title, string notes, bool isActive, bool isCorrespondent, int currencyId, Currency currency)
            : this(id, title, notes, isActive, isCorrespondent, currencyId, currency, new List<Transaction>(), new List<Transaction>())
        {
        }

        public int Id { get; set; }

        public string Title
        {
            get => this._title;
            set => this._title = EntityUtil.Set(value, TitleMaxLength, nameof(this.Title));
        }

        public string Notes
        {
            get => this._notes;
            set => this._notes = EntityUtil.Set(value, NotesMaxLength, nameof(this.Notes));
        }

        public bool IsActive { get; set; }

        public bool IsCorrespondent { get; set; }

        public int CurrencyId { get; set; }

        public Currency Currency { get; set; }

        public virtual ICollection<Transaction> SourceTransactions { get; set; }

        public virtual ICollection<Transaction> DestinationTransactions { get; set; }
    }
}