namespace Usol.Wally.Domain.Models
{
    public class Currency
    {
        public const int CodeMaxLength = 3;

        public int Id { get; set; }

        public string Code { get; set; }
    }
}