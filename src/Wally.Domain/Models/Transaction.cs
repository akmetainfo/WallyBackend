using System;
using System.Collections.Generic;
using Usol.Wally.Domain.Extensions;

namespace Usol.Wally.Domain.Models
{
    public class Transaction
    {
        public const int CommentMaxLength = 150;

        private string _comment;

        public Transaction()
        {
            this.TransactionCategories = new List<TransactionCategory>();
        }

        public Transaction(int id, DateTime created, decimal amountSource, decimal amountDestination, int sourceId, Account source, int destinationId, Account destination, bool @checked, string comment, ICollection<TransactionCategory> transactionCategories)
        {
            this.Id = id;
            this.Created = created;
            this.AmountSource = amountSource;
            this.AmountDestination = amountDestination;
            this.SourceId = sourceId;
            this.Source = source;
            this.DestinationId = destinationId;
            this.Destination = destination;
            this.Checked = @checked;
            this.Comment = comment;
            this.TransactionCategories = transactionCategories;
        }

        public Transaction(int id, DateTime created, decimal amountSource, decimal amountDestination, int sourceId, Account source, int destinationId, Account destination, bool @checked, string comment)
            : this(id, created, amountSource, amountDestination, sourceId, source, destinationId, destination, @checked, comment, new List<TransactionCategory>())
        {
        }

        public int Id { get; set; }

        public DateTime Created { get; set; }

        public decimal AmountSource { get; set; }

        public decimal AmountDestination { get; set; }

        public int SourceId { get; set; }

        public Account Source { get; set; }

        public int DestinationId { get; set; }

        public Account Destination { get; set; }

        public bool Checked { get; set; }

        public string Comment
        {
            get => this._comment;
            set => this._comment = EntityUtil.Set(value, CommentMaxLength, nameof(this.Comment));
        }

        public virtual ICollection<TransactionCategory> TransactionCategories { get; set; }
    }
}