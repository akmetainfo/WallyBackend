using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Usol.Wally.Persistence;
using MediatR;

namespace Usol.Wally.Application.Reports.CrookedCategorizedTransactions
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
                WITH REPORT AS
                (
                    SELECT
                         t.Id
                        , t.Created
                        , (SELECT SUM(tc.Amount) FROM dbo.TransactionCategories tc WHERE tc.TransactionId = t.Id) TransactionAmount
                        , CASE s.IsCorrespondent
                            WHEN 0 THEN t.AmountSource
                            WHEN 1 THEN t.AmountDestination
                            END AS Amount
                    FROM dbo.Transactions t
                    INNER JOIN dbo.Accounts s ON T.SourceId = s.Id
                    INNER JOIN dbo.Accounts d ON T.DestinationId = d.Id
                    WHERE 1 = 1
                        AND s.IsCorrespondent <> d.IsCorrespondent
                )
                SELECT
                      REPORT.Id
                    , REPORT.Created
                    , REPORT.Amount
                FROM REPORT
                WHERE 1 = 1
                    AND REPORT.TransactionAmount <> REPORT.Amount
                ORDER BY 1 DESC
            ";

            var transactions = await this.Db.QueryAsync<CrookedCategorizedTransaction>(new CommandDefinition(query, cancellationToken: cancellationToken));

            return new Result(transactions);
        }
    }
}
