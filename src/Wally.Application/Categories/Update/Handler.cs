using System.Threading;
using System.Threading.Tasks;
using Usol.Wally.Persistence;
using MediatR;

namespace Usol.Wally.Application.Categories.Update
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
            this.ApplicationDbContext.Categories.Update(entity);
            await this.ApplicationDbContext.SaveChangesAsync(cancellationToken);
            return CategoryData.FromEntity(entity);
        }
    }
}