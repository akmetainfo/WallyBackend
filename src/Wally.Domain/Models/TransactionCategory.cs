using Usol.Wally.Domain.Extensions;

namespace Usol.Wally.Domain.Models
{
    public class TransactionCategory
    {
        public const int CommentMaxLength = 90;

        private string _comment;

        public TransactionCategory()
        {
        }

        public TransactionCategory(int id, int transactionId, Transaction transaction, int categoryId, Category category, decimal amount, string comment)
        {
            this.Id = id;
            this.TransactionId = transactionId;
            this.Transaction = transaction;
            this.CategoryId = categoryId;
            this.Category = category;
            this.Amount = amount;
            this.Comment = comment;
        }

        public int Id { get; set; }

        public int TransactionId { get; set; }

        public Transaction Transaction { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public decimal Amount { get; set; }

        public string Comment
        {
            get => this._comment;
            set => this._comment = EntityUtil.Set(value, CommentMaxLength, nameof(this.Comment));
        }
    }
}