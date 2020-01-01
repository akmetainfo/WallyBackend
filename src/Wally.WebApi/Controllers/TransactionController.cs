using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Transactions = Usol.Wally.Application.Transactions;

namespace Usol.Wally.WebApi.Controllers
{
    public class TransactionController : BaseApiController
    {
        public TransactionController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpPost]
        public async Task<object> List(Transactions.List.Query query, CancellationToken cancellationToken)
        {
            var result = await this.Mediator.Send(query, cancellationToken);
            return result;
        }

        [HttpPost]
        public async Task<object> Detail(Transactions.GetTransaction.Query query, CancellationToken cancellationToken)
        {
            var result = await this.Mediator.Send(query, cancellationToken);
            return result;
        }

        [HttpPost]
        public async Task<object> Create(Transactions.Create.Command command, CancellationToken cancellationToken)
        {
            var result = await this.Mediator.Send(command, cancellationToken);
            return result;
        }

        [HttpPost]
        public async Task<object> Update(Transactions.Update.Command command, CancellationToken cancellationToken)
        {
            var result = await this.Mediator.Send(command, cancellationToken);
            return result;
        }

        [HttpPost]
        public async Task<object> Delete(Transactions.Delete.Command command, CancellationToken cancellationToken)
        {
            var result = await this.Mediator.Send(command, cancellationToken);
            return result;
        }
    }
}