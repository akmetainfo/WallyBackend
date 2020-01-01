using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Usol.Wally.Persistence;
using MediatR;

namespace Usol.Wally.Application.Reports.NonCategorizedTransactions
{
    public class Handler : BaseHandler, IRequestHandler<Query, Result>
    {
        public Handler(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public async Task<Result> Handle(Query request, CancellationToken cancellationToken)
        {
            const string query = @"
                SELECT
                      t.Id
                    , t.Created
                    , CASE s.IsCorrespondent
                        WHEN 0 THEN t.AmountSource
                        WHEN 1 THEN t.AmountDestination
                        END AS Amount
                FROM dbo.Transactions t
                INNER JOIN dbo.Accounts s ON T.SourceId = s.Id
                INNER JOIN dbo.Accounts d ON T.DestinationId = d.Id
                LEFT JOIN dbo.TransactionCategories tc ON tc.TransactionId = t.Id
                WHERE 1 = 1
                    AND tc.Id IS NULL
                    AND s.IsCorrespondent <> d.IsCorrespondent
                ORDER BY t.Created DESC
            ";

            var transactions = await this.Db.QueryAsync<NonCategorizedTransaction>(new CommandDefinition(query, cancellationToken: cancellationToken));

            return new Result(transactions);
        }
    }
}
