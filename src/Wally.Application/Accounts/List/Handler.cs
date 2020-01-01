using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Usol.Wally.Persistence;
using MediatR;
using MetaInfoRu.Common;
using Microsoft.EntityFrameworkCore;
using Usol.Wally.Domain.Models;

namespace Usol.Wally.Application.Accounts.List
{
    public class Handler : BaseHandler, IRequestHandler<Query, Result>
    {
        public Handler(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public async Task<Result> Handle(Query request, CancellationToken cancellationToken)
        {
            var query = this.ApplicationDbContext.Accounts
                            .Include(x => x.Currency)
                            .Where(x => true);

            query = ApplyFilters(query, request);

            query = query.OrderBy(x => x.Title);

            var accounts = await query.Paging(request)
                                      .AsNoTracking()
                                      .ToArrayAsync(cancellationToken);

            return new Result(accounts.Select(x => new AccountDto(x)), await query.CountAsync(cancellationToken));
        }

        private static IQueryable<Account> ApplyFilters(IQueryable<Account> query, Query request)
        {
            if (request.IsCorrespondent != null)
                query = query.Where(x => x.IsCorrespondent == request.IsCorrespondent);

            if (request.IsActive != null)
                query = query.Where(x => x.IsActive == request.IsActive);

            if (!string.IsNullOrWhiteSpace(request.Needle))
                query = query.Where(x => x.Title.Contains(request.Needle) || x.Notes.Contains(request.Needle));

            return query;
        }
    }
}
