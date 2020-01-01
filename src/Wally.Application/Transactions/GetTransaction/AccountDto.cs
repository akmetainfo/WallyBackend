namespace Usol.Wally.Application.Transactions.GetTransaction
{
    public class AccountDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsActive { get; set; }

        public bool IsCorrespondent { get; set; }

        public int CurrencyId { get; set; }

        public string CurrencyCode { get; set; }
    }
}