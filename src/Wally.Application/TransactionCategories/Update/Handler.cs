using System.Threading;
using System.Threading.Tasks;
using Usol.Wally.Persistence;
using MediatR;

namespace Usol.Wally.Application.TransactionCategories.Update
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
            this.ApplicationDbContext.TransactionCategories.Update(entity);
            await this.ApplicationDbContext.SaveChangesAsync(cancellationToken);
            return TransactionCategoryData.FromEntity(entity);
        }
    }
}