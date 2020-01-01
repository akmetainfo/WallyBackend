using System.Threading;
using System.Threading.Tasks;
using Usol.Wally.Persistence;
using MediatR;

namespace Usol.Wally.Application.Accounts.Update
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
            this.ApplicationDbContext.Accounts.Update(entity);
            await this.ApplicationDbContext.SaveChangesAsync(cancellationToken);
            return AccountData.FromEntity(entity);
        }
    }
}