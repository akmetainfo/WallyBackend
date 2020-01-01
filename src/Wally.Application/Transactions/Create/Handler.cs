using System.Threading;
using System.Threading.Tasks;
using Usol.Wally.Persistence;
using MediatR;

namespace Usol.Wally.Application.Transactions.Create
{
    public class Handler : BaseHandler, IRequestHandler<Command, TransactionData>
    {
        public Handler(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public async Task<TransactionData> Handle(Command request, CancellationToken cancellationToken)
        {
            var entity = request.Transaction.ToEntity();
            await this.ApplicationDbContext.Transactions.AddAsync(entity, cancellationToken);
            await this.ApplicationDbContext.SaveChangesAsync(cancellationToken);
            return TransactionData.FromEntity(entity);
        }
    }
}