using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Usol.Wally.Domain.Models;

namespace Usol.Wally.Application.Transactions.List
{
    public class TransactionDto
    {
        [JsonConstructor]
        public TransactionDto(int id, DateTime created, decimal amountSource, decimal amountDestination, int sourceId, bool sourceIsCorrespondent, string sourceTitle, int destinationId, bool destinationIsCorrespondent, string destinationTitle, string comment, bool @checked, IEnumerable<TransactionCategoryDto> categories)
        {
            this.Id = id;
            this.Created = created;
            this.AmountSource = amountSource;
            this.AmountDestination = amountDestination;
            this.SourceId = sourceId;
            this.SourceIsCorrespondent = sourceIsCorrespondent;
            this.SourceTitle = sourceTitle;
            this.DestinationId = destinationId;
            this.DestinationIsCorrespondent = destinationIsCorrespondent;
            this.DestinationTitle = destinationTitle;
            this.Comment = comment;
            this.Checked = @checked;
            this.Categories = categories;
        }

        public TransactionDto(Transaction transaction)
        {
            this.Id = transaction.Id;
            this.Created = transaction.Created;
            this.AmountSource = transaction.AmountSource;
            this.AmountDestination = transaction.AmountDestination;
            this.SourceId = transaction.SourceId;
            this.SourceIsCorrespondent = transaction.Source.IsCorrespondent;
            this.SourceTitle = transaction.Source.Title;
            this.DestinationId = transaction.DestinationId;
            this.DestinationIsCorrespondent = transaction.Destination.IsCorrespondent;
            this.DestinationTitle = transaction.Destination.Title;
            this.Comment = transaction.Comment;
            this.Checked = transaction.Checked;
            this.Categories = transaction.TransactionCategories.Select(x => new TransactionCategoryDto(x));
        }

        public int Id { get; }

        public DateTime Created { get; }

        public decimal AmountSource { get; set; }

        public decimal AmountDestination { get; set; }

        public int SourceId { get; }

        public bool SourceIsCorrespondent { get; }

        public string SourceTitle { get; }

        public int DestinationId { get; }

        public bool DestinationIsCorrespondent { get; }

        public string DestinationTitle { get; }

        public string Comment { get; }

        public bool Checked { get; }

        public IEnumerable<TransactionCategoryDto> Categories { get; }
    }
}