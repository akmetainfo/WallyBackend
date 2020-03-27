using Usol.Wally.Domain.Extensions;

namespace Usol.Wally.Domain.Models
{
    public class Currency
    {
        public const int CodeMaxLength = 3;

        private string _code;

        public Currency()
        {
        }

        public Currency(int id, string code)
        {
            this.Id = id;
            this.Code = code;
        }

        public int Id { get; set; }

        public string Code
        {
            get => this._code;
            set => this._code = EntityUtil.Set(value, CodeMaxLength, nameof(this.Code));
        }
    }
}