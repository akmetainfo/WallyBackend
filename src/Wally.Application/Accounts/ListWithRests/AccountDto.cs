namespace Usol.Wally.Application.Accounts.ListWithRests
{
    public class AccountDto
    {
        public int Id { get; }

        public string Title { get; }

        public string Notes { get; }

        public bool IsActive { get; }

        public decimal Rest { get; }
    }
}