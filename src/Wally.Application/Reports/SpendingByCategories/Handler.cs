using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Usol.Wally.Persistence;
using MediatR;

namespace Usol.Wally.Application.Reports.SpendingByCategories
{
    public class Handler : BaseHandler, IRequestHandler<Query, IEnumerable<SpendingByCategoryDto>>
    {
        public Handler(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public Task<IEnumerable<SpendingByCategoryDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            const string query = @"
                SELECT
                      tc.CategoryId
                    , SUM(tc.Amount * s.IsCorrespondent) Income
                    , SUM(tc.Amount * d.IsCorrespondent) Expense
                    , (SUM(tc.Amount * d.IsCorrespondent) - SUM(tc.Amount * s.IsCorrespondent)) Amount
                    , c.Title CategoryTitle
                FROM dbo.TransactionCategories tc
                INNER JOIN dbo.Categories c ON tc.CategoryId = c.Id
                INNER JOIN dbo.Transactions t ON tc.TransactionId = T.Id
                INNER JOIN dbo.Accounts s ON t.SourceId = s.Id
                INNER JOIN dbo.Accounts d ON t.DestinationId = d.Id
                WHERE 1 = 1
                    AND t.Created >= @FromDate
                    AND t.Created < @ToDate
                GROUP BY tc.CategoryId, c.Title
                ORDER BY Amount DESC
            ";

            var parameters = new
            {
                @FromDate = request.FromDate,
                @ToDate = request.ToDate,
            };

            return this.Db.QueryAsync<SpendingByCategoryDto>(new CommandDefinition(query, parameters, cancellationToken: cancellationToken));
        }
    }
}