using System.Threading;
using System.Threading.Tasks;
using Usol.Wally.Persistence;
using Usol.Wally.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Usol.Wally.Application.Transactions.Get
{
    public class Handler : BaseHandler, IRequestHandler<Query, Transaction>
    {
        public Handler(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public Task<Transaction> Handle(Query request, CancellationToken cancellationToken)
        {
            return this.ApplicationDbContext.Transactions
                             .Include(x => x.Source)
                             .Include(x => x.Destination)
                             .AsNoTracking()
                             .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        }
    }
}