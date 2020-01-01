using Usol.Wally.Domain.Models;

namespace Usol.Wally.Application.Accounts.Details
{
    public class DetailsDto
    {
        public DetailsDto(Account account)
        {
            this.Id = account.Id;
            this.Title = account.Title;
            this.Notes = account.Notes;
            this.IsActive = account.IsActive;
            this.IsCorrespondent = account.IsCorrespondent;
            this.CurrencyId = account.CurrencyId;
            this.CurrencyCode = account.Currency?.Code;
        }

        public int Id { get; }

        public string Title { get; }

        public string Notes { get; }

        public bool IsActive { get; }

        public bool IsCorrespondent { get; }

        public int? CurrencyId { get; }

        public string CurrencyCode { get; }
    }
}