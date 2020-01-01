using MediatR;

namespace Usol.Wally.Application.Transactions.Create
{
    public class Command : IRequest<TransactionData>
    {
        public Command(TransactionData transaction)
        {
            this.Transaction = transaction;
        }

        public TransactionData Transaction { get; }
    }
}