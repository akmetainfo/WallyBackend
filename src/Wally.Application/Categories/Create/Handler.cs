using System.Threading;
using System.Threading.Tasks;
using Usol.Wally.Persistence;
using MediatR;

namespace Usol.Wally.Application.Categories.Create
{
    public class Handler : BaseHandler, IRequestHandler<Command, CategoryData>
    {
        public Handler(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public async Task<CategoryData> Handle(Command request, CancellationToken cancellationToken)
        {
            var entity = request.Category.ToEntity();
            await this.ApplicationDbContext.Categories.AddAsync(entity, cancellationToken);
            await this.ApplicationDbContext.SaveChangesAsync(cancellationToken);
            return CategoryData.FromEntity(entity);
        }
    }
}