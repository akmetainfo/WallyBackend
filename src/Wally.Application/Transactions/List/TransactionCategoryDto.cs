using Usol.Wally.Domain.Models;

namespace Usol.Wally.Application.Transactions.List
{
    public class TransactionCategoryDto
    {
        public TransactionCategoryDto(int id, int categoryId, string categoryTitle, decimal amount, string comment)
        {
            this.Id = id;
            this.CategoryId = categoryId;
            this.CategoryTitle = categoryTitle;
            this.Amount = amount;
            this.Comment = comment;
        }

        public TransactionCategoryDto(TransactionCategory x)
            : this(x.Id, x.CategoryId, x.Category.Title, x.Amount, x.Comment)
        {
        }

        public int Id { get; }

        public int CategoryId { get; }

        public string CategoryTitle { get; }

        public decimal Amount { get; }

        public string Comment { get; }
    }
}