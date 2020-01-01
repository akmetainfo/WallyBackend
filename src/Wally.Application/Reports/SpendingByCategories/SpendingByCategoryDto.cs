namespace Usol.Wally.Application.Reports.SpendingByCategories
{
    public class SpendingByCategoryDto
    {
        public int CategoryId { get; set; }

        public string CategoryTitle { get; set; }

        public decimal Expense { get; set; }

        public decimal Income { get; set; }

        public decimal Amount { get; set; }
    }
}