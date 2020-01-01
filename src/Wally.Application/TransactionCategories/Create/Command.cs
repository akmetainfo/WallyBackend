using MediatR;

namespace Usol.Wally.Application.TransactionCategories.Create
{
    public class Command : IRequest<TransactionCategoryData>
    {
        public Command(TransactionCategoryData transactionCategory)
        {
            this.TransactionCategory = transactionCategory;
        }

        public TransactionCategoryData TransactionCategory { get; }
    }
}