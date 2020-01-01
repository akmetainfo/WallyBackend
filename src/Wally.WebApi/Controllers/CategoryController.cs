using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Categories = Usol.Wally.Application.Categories;

namespace Usol.Wally.WebApi.Controllers
{
    public class CategoryController : BaseApiController
    {
        public CategoryController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpPost]
        public async Task<object> List(Categories.List.Query query, CancellationToken cancellationToken)
        {
            var result = await this.Mediator.Send(query, cancellationToken);
            return result;
        }

        [HttpPost]
        public async Task<object> Details(Categories.Details.Query query, CancellationToken cancellationToken)
        {
            var result = await this.Mediator.Send(query, cancellationToken);
            return result;
        }

        [HttpPost]
        public async Task<object> Create(Categories.Create.Command command, CancellationToken cancellationToken)
        {
            var result = await this.Mediator.Send(command, cancellationToken);
            return result;
        }

        [HttpPost]
        public async Task<object> Update(Categories.Update.Command command, CancellationToken cancellationToken)
        {
            var result = await this.Mediator.Send(command, cancellationToken);
            return result;
        }
    }
}