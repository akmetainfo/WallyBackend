using Usol.Wally.Domain.Models;
using MediatR;

namespace Usol.Wally.Application.Transactions.Get
{
    public class Query : IRequest<Transaction>
    {
        public int Id { get; set; }
    }
}