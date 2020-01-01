using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Usol.Wally.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Usol.Wally.Application.Categories.Details
{
    public class Handler : BaseHandler, IRequestHandler<Query, DetailsDto>
    {
        public Handler(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public async Task<DetailsDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var account = await this.ApplicationDbContext.Categories
                                    .Where(x => x.Id == request.CategoryId)
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(cancellationToken);

            return account == null ? null : new DetailsDto(account);
        }
    }
}