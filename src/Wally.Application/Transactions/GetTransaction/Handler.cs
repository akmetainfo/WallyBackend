using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Usol.Wally.Persistence;
using Usol.Wally.Domain.Models;
using MediatR;

namespace Usol.Wally.Application.Transactions.GetTransaction
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
                    , t.AmountSource
                    , t.AmountDestination
                    , t.Checked
                    , t.Comment
                FROM dbo.Transactions t
                WHERE 1 = 1
                    AND t.Id = @transactionId

                SELECT
                      a.Id
                    , a.Title
                    , a.IsActive
                    , a.IsCorrespondent
                    , a.CurrencyId
                    , c.Code CurrencyCode
                FROM dbo.Accounts a
                INNER JOIN dbo.Transactions t ON t.SourceId = a.Id
                INNER JOIN dbo.Currencies c ON a.CurrencyId = c.Id
                WHERE 1 = 1
                    AND t.Id = @transactionId

                SELECT
                      a.Id
                    , a.Title
                    , a.IsActive
                    , a.IsCorrespondent
                    , a.CurrencyId
                    , c.Code CurrencyCode
                FROM dbo.Accounts a
                INNER JOIN dbo.Transactions t ON t.DestinationId = a.Id
                INNER JOIN dbo.Currencies c ON a.CurrencyId = c.Id
                WHERE 1 = 1
                    AND t.Id = @transactionId

                SELECT
                      tc.Id
                    , tc.CategoryId
                    , tc.Amount
                    , tc.Comment
                    , c.Title CategoryTitle
                FROM dbo.TransactionCategories tc
                INNER JOIN dbo.Categories c ON c.Id = tc.CategoryId
                WHERE 1 = 1
                    AND tc.TransactionId = @transactionId
            ";

            var parameters = new
            {
                @transactionId = request.TransactionId,
            };

            using (var multi = this.Db.QueryMultiple(new CommandDefinition(query, parameters, cancellationToken: cancellationToken)))
            {
                var transaction = await multi.ReadFirstOrDefaultAsync<TransactionDto>();
                var source = await multi.ReadFirstOrDefaultAsync<AccountDto>();
                var destination = await multi.ReadFirstOrDefaultAsync<AccountDto>();
                var categories = await multi.ReadAsync<TransactionCategoryDto>();

                return new Result
                {
                    Transaction = transaction,
                    Source = source,
                    Destination = destination,
                    Categories = categories,
                };
            }
        }
    }
}