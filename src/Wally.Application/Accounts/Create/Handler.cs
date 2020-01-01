using System.Threading;
using System.Threading.Tasks;
using Usol.Wally.Persistence;
using MediatR;

namespace Usol.Wally.Application.Accounts.Create
{
    public class Handler : BaseHandler, IRequestHandler<Command, AccountData>
    {
        public Handler(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public async Task<AccountData> Handle(Command request, CancellationToken cancellationToken)
        {
            var entity = request.Account.ToEntity();
            await this.ApplicationDbContext.Accounts.AddAsync(entity, cancellationToken);
            await this.ApplicationDbContext.SaveChangesAsync(cancellationToken);
            return AccountData.FromEntity(entity);
        }
    }
}