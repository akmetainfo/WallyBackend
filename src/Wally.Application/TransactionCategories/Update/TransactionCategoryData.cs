using Newtonsoft.Json;
using Usol.Wally.Domain.Models;

namespace Usol.Wally.Application.TransactionCategories.Update
{
    public class TransactionCategoryData
    {
        [JsonConstructor]
        public TransactionCategoryData(int id, int transactionId, int categoryId, decimal amount, string comment)
        {
            this.Id = id;
            this.TransactionId = transactionId;
            this.CategoryId = categoryId;
            this.Amount = amount;
            this.Comment = comment;
        }

        public int Id { get; }

        public int TransactionId { get; }

        public int CategoryId { get; }

        public decimal Amount { get; }

        public string Comment { get; }

        public static TransactionCategoryData FromEntity(TransactionCategory entity)
        {
            return new TransactionCategoryData(entity.Id, entity.TransactionId, entity.CategoryId, entity.Amount, entity.Comment);
        }

        public TransactionCategory ToEntity()
        {
            return new TransactionCategory
            {
                Id = this.Id,
                TransactionId = this.TransactionId,
                CategoryId = this.CategoryId,
                Amount = this.Amount,
                Comment = this.Comment,
            };
        }
    }
}