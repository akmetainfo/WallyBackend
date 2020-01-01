using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Usol.Wally.Persistence;
using MediatR;
using MetaInfoRu.Common;
using Microsoft.EntityFrameworkCore;

namespace Usol.Wally.Application.Categories.List
{
    public class Handler : BaseHandler, IRequestHandler<Query, Result>
    {
        public Handler(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public async Task<Result> Handle(Query request, CancellationToken cancellationToken)
        {
            var query = this.ApplicationDbContext.Categories.Where(x => true);

            query = query.OrderBy(x => x.Title);

            var categories = await query.Paging(request)
                                        .AsNoTracking()
                                        .ToArrayAsync(cancellationToken);

            return new Result(categories.Select(x => new CategoryDto(x)), await query.CountAsync(cancellationToken));
        }
    }
}
