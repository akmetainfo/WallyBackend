using Newtonsoft.Json;
using Usol.Wally.Domain.Models;

namespace Usol.Wally.Application.Accounts.Create
{
    public class AccountData
    {
        [JsonConstructor]
        public AccountData(int id, string title, string notes, bool isActive, bool isCorrespondent, int currencyId)
        {
            this.Id = id;
            this.Title = title;
            this.Notes = notes;
            this.IsActive = isActive;
            this.IsCorrespondent = isCorrespondent;
            this.CurrencyId = currencyId;
        }

        public int Id { get; }

        public string Title { get; }

        public string Notes { get; }

        public bool IsActive { get; }

        public bool IsCorrespondent { get; }

        public int CurrencyId { get; }

        public static AccountData FromEntity(Account entity)
        {
            return new AccountData(entity.Id, entity.Title, entity.Notes, entity.IsActive, entity.IsCorrespondent, entity.CurrencyId);
        }

        public Account ToEntity()
        {
            return new Account
            {
                Id = this.Id,
                Title = this.Title,
                Notes = this.Notes ?? string.Empty,
                IsActive = this.IsActive,
                IsCorrespondent = this.IsCorrespondent,
                CurrencyId = this.CurrencyId,
            };
        }
    }
}