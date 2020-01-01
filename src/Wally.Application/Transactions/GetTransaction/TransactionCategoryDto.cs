namespace Usol.Wally.Application.Transactions.GetTransaction
{
    public class TransactionCategoryDto
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string CategoryTitle { get; set; }

        public decimal Amount { get; set; }

        public string Comment { get; set; }
    }
}