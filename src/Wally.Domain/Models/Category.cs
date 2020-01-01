using System.Collections.Generic;

namespace Usol.Wally.Domain.Models
{
    public class Category
    {
        public const int TitleMaxLength = 50;

        public int Id { get; set; }

        public string Title { get; set; }

        public virtual IEnumerable<TransactionCategory> TransactionCategories { get; set; }
    }
}