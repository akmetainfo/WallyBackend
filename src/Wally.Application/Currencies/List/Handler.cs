using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Usol.Wally.Persistence;
using MediatR;
using MetaInfoRu.Common;
using Microsoft.EntityFrameworkCore;

namespace Usol.Wally.Application.Currencies.List
{
    public class Handler : BaseHandler, IRequestHandler<Query, Result>
    {
        public Handler(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public async Task<Result> Handle(Query request, CancellationToken cancellationToken)
        {
            var query = this.ApplicationDbContext.Currencies.Where(x => true);

            query = query.OrderBy(x => x.Id);

            var categories = await query.Paging(request)
                                        .AsNoTracking()
                                        .ToArrayAsync(cancellationToken);

            return new Result(categories.Select(x => new CurrencyDto(x)), await query.CountAsync(cancellationToken));
        }
    }
}