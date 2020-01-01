using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Usol.Wally.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Usol.Wally.Application.Accounts.Details
{
    public class Handler : BaseHandler, IRequestHandler<Query, DetailsDto>
    {
        public Handler(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public async Task<DetailsDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var account = await this.ApplicationDbContext.Accounts
                                    .Include(x => x.Currency)
                                    .Where(x => x.Id == request.AccountId)
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(cancellationToken);

            return account == null ? null : new DetailsDto(account);
        }
    }
}