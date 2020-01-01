using System;
using Newtonsoft.Json;
using Usol.Wally.Domain.Models;

namespace Usol.Wally.Application.Transactions.Create
{
    public class TransactionData
    {
        [JsonConstructor]
        public TransactionData(int id, DateTime created, decimal amountSource, decimal amountDestination, int sourceId, string sourceTitle, int destinationId, string destinationTitle, bool @checked, string comment)
        {
            this.Id = id;
            this.Created = created;
            this.AmountSource = amountSource;
            this.AmountDestination = amountDestination;
            this.SourceId = sourceId;
            this.SourceTitle = sourceTitle;
            this.DestinationId = destinationId;
            this.DestinationTitle = destinationTitle;
            this.Checked = @checked;
            this.Comment = comment;
        }

        public int Id { get; }

        public DateTime Created { get; }

        public decimal AmountSource { get; }

        public decimal AmountDestination { get; }

        public int SourceId { get; }

        public string SourceTitle { get; }

        public int DestinationId { get; }

        public string DestinationTitle { get; }

        public bool Checked { get; }

        public string Comment { get; }

        public static TransactionData FromEntity(Transaction entity)
        {
            return new TransactionData(entity.Id, entity.Created, entity.AmountSource, entity.AmountDestination, entity.SourceId, entity.Source?.Title, entity.DestinationId, entity.Destination?.Title, entity.Checked, entity.Comment);
        }

        public Transaction ToEntity()
        {
            return new Transaction
            {
                Id = this.Id,
                Created = this.Created,
                AmountSource = this.AmountSource,
                AmountDestination = this.AmountDestination,
                SourceId = this.SourceId,
                DestinationId = this.DestinationId,
                Checked = this.Checked,
                Comment = this.Comment,
            };
        }
    }
}