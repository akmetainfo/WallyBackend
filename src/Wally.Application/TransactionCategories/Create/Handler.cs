using System.Threading;
using System.Threading.Tasks;
using Usol.Wally.Persistence;
using MediatR;

namespace Usol.Wally.Application.TransactionCategories.Create
{
    public class Handler : BaseHandler, IRequestHandler<Command, TransactionCategoryData>
    {
        public Handler(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public async Task<TransactionCategoryData> Handle(Command request, CancellationToken cancellationToken)
        {
            var entity = request.TransactionCategory.ToEntity();
            await this.ApplicationDbContext.TransactionCategories.AddAsync(entity, cancellationToken);
            await this.ApplicationDbContext.SaveChangesAsync(cancellationToken);
            return TransactionCategoryData.FromEntity(entity);
        }
    }
}