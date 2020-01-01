using System.Threading;
using System.Threading.Tasks;
using Usol.Wally.Persistence;
using Usol.Wally.Domain.Models;
using MediatR;

namespace Usol.Wally.Application.TransactionCategories.Delete
{
    public class Handler : BaseHandler, IRequestHandler<Command, int>
    {
        public Handler(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public Task<int> Handle(Command request, CancellationToken cancellationToken)
        {
            var entity = new TransactionCategory { Id = request.TransactionCategoryId };
            this.ApplicationDbContext.TransactionCategories.Remove(entity);
            return this.ApplicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}