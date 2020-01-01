using Usol.Wally.Domain.Models;

namespace Usol.Wally.Application.Currencies.List
{
    public class CurrencyDto
    {
        public CurrencyDto(Currency currency)
        {
            this.Id = currency.Id;
            this.Code = currency.Code;
        }

        public int Id { get; }

        public string Code { get; }
    }
}