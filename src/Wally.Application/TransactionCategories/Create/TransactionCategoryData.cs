using System;
using Usol.Wally.Domain.Models;

namespace Usol.Wally.Application.TransactionCategories.Create
{
    public class TransactionCategoryData
    {
        [Obsolete("For asp.net MVC Razor Pages only")]
        public TransactionCategoryData()
        {
        }

        public TransactionCategoryData(int id, int transactionId, int categoryId, decimal amount, string comment)
        {
            this.Id = id;
            this.TransactionId = transactionId;
            this.CategoryId = categoryId;
            this.Amount = amount;
            this.Comment = comment;
        }

        public int Id { get; set; }

        public int TransactionId { get; set; }

        public int CategoryId { get; set; }

        public decimal Amount { get; set; }

        public string Comment { get; set; }

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