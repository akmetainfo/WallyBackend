using MediatR;

namespace Usol.Wally.Application.Transactions.Delete
{
    public class Command : IRequest<int>
    {
        public int TransactionId { get; set; }
    }
}