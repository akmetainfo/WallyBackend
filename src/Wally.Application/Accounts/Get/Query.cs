using Usol.Wally.Domain.Models;
using MediatR;

namespace Usol.Wally.Application.Accounts.Get
{
    public class Query : IRequest<Account>
    {
        public Query(int id)
        {
            this.Id = id;
        }

        public int Id { get; }
    }
}