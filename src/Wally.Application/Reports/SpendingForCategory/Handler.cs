using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Usol.Wally.Application.Transactions.List;
using Dapper;
using Usol.Wally.Persistence;
using MediatR;

namespace Usol.Wally.Application.Reports.SpendingForCategory
{
    public class Handler : BaseHandler, IRequestHandler<Query, IEnumerable<TransactionDto>>
    {
        public Handler(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public Task<IEnumerable<TransactionDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            const string query = @"
                SELECT
                      DISTINCT t.Id
                    , t.Created
                    , t.Amount
                    , t.SourceId
                    , t.DestinationId
                    , t.Checked
                    , t.Comment
                    , s.IsCorrespondent SourceIsCorrespondent
                    , s.Title SourceTitle
                    , d.IsCorrespondent DestinationIsCorrespondent
                    , d.Title DestinationTitle
                    , (SELECT COUNT(*) FROM dbo.TransactionCategories tc WHERE T.Id = tc.TransactionId) CategoriesCount
                    , (SELECT TOP 1 c.Title FROM dbo.TransactionCategories tc INNER JOIN dbo.Categories c ON c.Id = tc.CategoryId WHERE T.Id = tc.TransactionId) CategoryTitle
                FROM dbo.TransactionCategories tc
                INNER JOIN dbo.Categories c ON tc.CategoryId = c.Id
                INNER JOIN dbo.Transactions t ON tc.TransactionId = T.Id
                INNER JOIN dbo.Accounts s ON t.SourceId = s.Id
                INNER JOIN dbo.Accounts d ON t.DestinationId = d.Id
                WHERE 1 = 1
                    AND t.Created >= @FromDate
                    AND t.Created < @ToDate
                    AND tc.CategoryId = @CategoryId
            ";

            var parameters = new
            {
                @FromDate = request.FromDate,
                @ToDate   = request.ToDate,
                @CategoryId = request.CategoryId,
            };

            return this.Db.QueryAsync<TransactionDto>(new CommandDefinition(query, parameters, cancellationToken: cancellationToken));
        }
    }
}