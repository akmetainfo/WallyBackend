using MediatR;

namespace Usol.Wally.Application.Transactions.GetTransaction
{
    public class Query : IRequest<Result>
    {
        public int TransactionId { get; set; }
    }
}