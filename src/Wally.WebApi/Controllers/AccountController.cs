using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Accounts = Usol.Wally.Application.Accounts;

namespace Usol.Wally.WebApi.Controllers
{
    public class AccountController : BaseApiController
    {
        public AccountController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpPost]
        public async Task<object> List(Accounts.List.Query query, CancellationToken cancellationToken)
        {
            var result = await this.Mediator.Send(query, cancellationToken);
            return result;
        }

        [HttpPost]
        public async Task<object> ListWithRests(Accounts.ListWithRests.Query query, CancellationToken cancellationToken)
        {
            var result = await this.Mediator.Send(query, cancellationToken);
            return result;
        }

        [HttpPost]
        public async Task<object> QuickSearch(Accounts.List.Query query, CancellationToken cancellationToken)
        {
            var result = await this.Mediator.Send(query, cancellationToken);
            return result;
        }

        [HttpPost]
        public async Task<object> Index(Accounts.Details.Query query, CancellationToken cancellationToken)
        {
            var result = await this.Mediator.Send(query, cancellationToken);
            return result;
        }

        [HttpPost]
        public async Task<object> Create(Accounts.Create.Command command, CancellationToken cancellationToken)
        {
            var result = await this.Mediator.Send(command, cancellationToken);
            return result;
        }

        [HttpPost]
        public async Task<object> Update(Accounts.Update.Command command, CancellationToken cancellationToken)
        {
            var result = await this.Mediator.Send(command, cancellationToken);
            return result;
        }

        [HttpPost]
        public async Task<object> Merge(Accounts.Merge.Command command, CancellationToken cancellationToken)
        {
            var result = await this.Mediator.Send(command, cancellationToken);
            return result;
        }
    }
}