using System.Threading;
using System.Threading.Tasks;
using Usol.Wally.Persistence;
using Usol.Wally.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Usol.Wally.Application.TransactionCategories.Get
{
    public class Handler : BaseHandler, IRequestHandler<Query, TransactionCategory>
    {
        public Handler(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public Task<TransactionCategory> Handle(Query request, CancellationToken cancellationToken)
        {
            return this.ApplicationDbContext.TransactionCategories
                             .AsNoTracking()
                             .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        }
    }
}