using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MetaInfoRu.Common;
using Usol.Wally.Persistence;
using Usol.Wally.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Usol.Wally.Application.Transactions.List
{
    public class Handler : BaseHandler, IRequestHandler<Query, Result>
    {
        public Handler(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public async Task<Result> Handle(Query request, CancellationToken cancellationToken)
        {
            var query = this.ApplicationDbContext.Transactions
                            .Include(x => x.TransactionCategories)
                            .ThenInclude(x => x.Category)
                            .Include(x => x.Source)
                            .Include(x => x.Destination)
                            .Where(x => true);

            query = ApplyFilters(query, request);

            query = query.OrderByDescending(x => x.Created);

            var accounts = await query.Paging(request)
                                      .AsNoTracking()
                                      .ToArrayAsync(cancellationToken);

            return new Result(accounts.Select(x => new TransactionDto(x)), await query.CountAsync(cancellationToken));
        }

        private static IQueryable<Transaction> ApplyFilters(IQueryable<Transaction> query, Query request)
        {
            if (request.AccountId != null)
                query = query.Where(x => x.SourceId == request.AccountId || x.DestinationId == request.AccountId);

            if (request.HideChecked)
                query = query.Where(x => !x.Checked);

            if (request.HideInternalTransfers)
                query = query.Where(x => !x.Source.IsCorrespondent && !x.Destination.IsCorrespondent);

            if (request.AmountFrom != null)
                query = query.Where(x => x.AmountSource >= request.AmountFrom || x.AmountDestination >= request.AmountFrom);

            if (request.AmountTo != null)
                query = query.Where(x => x.AmountSource <= request.AmountTo || x.AmountDestination <= request.AmountTo);

            if (request.CategoryId != null)
                query = query.Where(x => x.TransactionCategories.Any(y => y.CategoryId == request.CategoryId));

            if (request.FromDate != null)
                query = query.Where(x => x.Created >= request.FromDate);

            if (request.ToDate != null)
                query = query.Where(x => x.Created <= request.ToDate);

            return query;
        }
    }
}