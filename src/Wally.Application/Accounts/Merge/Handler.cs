using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Usol.Wally.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Usol.Wally.Domain.Models;

namespace Usol.Wally.Application.Accounts.Merge
{
    public class Handler : AsyncRequestHandler<Command>
    {
        public Handler(ApplicationDbContext applicationDbContext)
        {
            this.ApplicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
        }

        private readonly ApplicationDbContext ApplicationDbContext;

        protected override async Task Handle(Command request, CancellationToken cancellationToken)
        {
            using (var transaction = await this.ApplicationDbContext.Database.BeginTransactionAsync(cancellationToken))
            {
                await this.ApplicationDbContext.Transactions
                          .Where(x => x.SourceId == request.MergedId)
                          .ForEachAsync(x => x.SourceId = request.PrimaryId, cancellationToken: cancellationToken);

                await this.ApplicationDbContext.Transactions
                          .Where(x => x.DestinationId == request.MergedId)
                          .ForEachAsync(x => x.DestinationId = request.PrimaryId, cancellationToken: cancellationToken);

                this.ApplicationDbContext.Accounts.Remove(new Account { Id = request.MergedId });

                await this.ApplicationDbContext.SaveChangesAsync(cancellationToken);

                transaction.Commit();
            }
        }
    }
}