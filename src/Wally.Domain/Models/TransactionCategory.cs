namespace Usol.Wally.Domain.Models
{
    public class TransactionCategory
    {
        public const int CommentMaxLength = 90;

        public int Id { get; set; }

        public int TransactionId { get; set; }

        public Transaction Transaction { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public decimal Amount { get; set; }

        public string Comment { get; set; }
    }
}