using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Usol.Wally.Persistence;
using MediatR;

namespace Usol.Wally.Application.Accounts.ListWithRests
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
                      a.Id
                    , a.Title
                    , a.IsActive
                    , a.IsCorrespondent
                    , a.CurrencyId
                    , ((SELECT ISNULL(SUM(AmountDestination), 0) FROM dbo.Transactions t2 WHERE a.Id = t2.DestinationId) - (SELECT ISNULL(SUM(AmountSource), 0) FROM dbo.Transactions t1 WHERE a.Id = t1.SourceId)) Rest
                FROM dbo.Accounts a
                WHERE 1 = 1
                    AND a.IsCorrespondent = 0
                    AND a.IsActive = 1
                ORDER BY a.Title
            ";

            var accounts = await this.Db.QueryAsync<AccountDto>(new CommandDefinition(query, cancellationToken: cancellationToken));

            return new Result(accounts);
        }
    }
}