using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Currencies = Usol.Wally.Application.Currencies;

namespace Usol.Wally.WebApi.Controllers
{
    public class CurrencyController : BaseApiController
    {
        public CurrencyController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpPost]
        public async Task<object> List(Currencies.List.Query query, CancellationToken cancellationToken)
        {
            var result = await this.Mediator.Send(query, cancellationToken);
            return result;
        }
    }
}