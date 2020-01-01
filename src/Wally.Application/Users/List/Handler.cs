using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Usol.Wally.Persistence;
using MediatR;
using MetaInfoRu.Common;
using Microsoft.EntityFrameworkCore;

namespace Usol.Wally.Application.Users.List
{
    public class Handler : BaseHandler, IRequestHandler<Query, Result>
    {
        public Handler(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public async Task<Result> Handle(Query request, CancellationToken cancellationToken)
        {
            var query = this.ApplicationDbContext.Users.Where(x => true);

            query = query.OrderBy(x => x.Id);

            var users = await query.Paging(request)
                                   .AsNoTracking()
                                   .ToArrayAsync(cancellationToken);

            return new Result(users.Select(x => new UserDto(x)), await query.CountAsync(cancellationToken));
        }
    }
}