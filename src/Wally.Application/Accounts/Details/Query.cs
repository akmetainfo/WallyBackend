using MediatR;

namespace Usol.Wally.Application.Accounts.Details
{
    public class Query : IRequest<DetailsDto>
    {
        public Query(int accountId)
        {
            this.AccountId = accountId;
        }

        public int AccountId { get; }
    }
}