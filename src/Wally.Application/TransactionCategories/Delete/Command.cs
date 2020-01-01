using MediatR;

namespace Usol.Wally.Application.TransactionCategories.Delete
{
    public class Command : IRequest<int>
    {
        public int TransactionCategoryId { get; set; }
    }
}