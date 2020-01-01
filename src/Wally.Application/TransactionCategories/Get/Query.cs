using Usol.Wally.Domain.Models;
using MediatR;

namespace Usol.Wally.Application.TransactionCategories.Get
{
    public class Query : IRequest<TransactionCategory>
    {
        public Query(int id)
        {
            this.Id = id;
        }

        public int Id { get; }
    }
}