using System.Threading;
using System.Threading.Tasks;
using Usol.Wally.Persistence;
using Usol.Wally.Domain.Models;
using MediatR;

namespace Usol.Wally.Application.Transactions.Delete
{
    public class Handler : BaseHandler, IRequestHandler<Command, int>
    {
        public Handler(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public Task<int> Handle(Command request, CancellationToken cancellationToken)
        {
            var entity = new Transaction { Id = request.TransactionId };
            this.ApplicationDbContext.Transactions.Remove(entity);
            return this.ApplicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}