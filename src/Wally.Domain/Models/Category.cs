using System.Collections.Generic;
using Usol.Wally.Domain.Extensions;

namespace Usol.Wally.Domain.Models
{
    public class Category
    {
        public const int TitleMaxLength = 50;

        private string _title;

        public Category()
        {
            this.TransactionCategories = new List<TransactionCategory>();
        }

        public Category(int id, string title, ICollection<TransactionCategory> transactionCategories)
        {
            this.Id = id;
            this.Title = title;
            this.TransactionCategories = transactionCategories;
        }

        public Category(int id, string title)
            : this(id, title, new List<TransactionCategory>())
        {
        }

        public int Id { get; set; }

        public string Title
        {
            get => this._title;
            set => this._title = EntityUtil.Set(value, TitleMaxLength, nameof(this.Title));
        }

        public virtual ICollection<TransactionCategory> TransactionCategories { get; set; }
    }
}