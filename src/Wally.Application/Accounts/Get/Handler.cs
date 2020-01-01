using System.Threading;
using System.Threading.Tasks;
using Usol.Wally.Persistence;
using Usol.Wally.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Usol.Wally.Application.Accounts.Get
{
    public class Handler : BaseHandler, IRequestHandler<Query, Account>
    {
        public Handler(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public Task<Account> Handle(Query request, CancellationToken cancellationToken)
        {
            return this.ApplicationDbContext.Accounts
                       .AsNoTracking()
                       .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        }
    }
}