using System.Collections.Generic;

namespace Usol.Wally.Application.Currencies.List
{
    public class Result
    {
        public Result(IEnumerable<CurrencyDto> currencies, int totalElements)
        {
            this.Currencies = currencies;
            this.TotalElements = totalElements;
        }

        public IEnumerable<CurrencyDto> Currencies { get; }

        public int TotalElements { get; }
    }
}