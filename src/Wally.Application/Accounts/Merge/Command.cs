using MediatR;

namespace Usol.Wally.Application.Accounts.Merge
{
    public class Command : IRequest
    {
        public Command(int primaryId, int mergedId)
        {
            this.PrimaryId = primaryId;
            this.MergedId = mergedId;
        }

        public int PrimaryId { get; }

        public int MergedId { get; }
    }
}