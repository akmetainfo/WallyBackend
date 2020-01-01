using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransactionCategory = Usol.Wally.Application.TransactionCategories;

namespace Usol.Wally.WebApi.Controllers
{
    public class TransactionCategoryController : BaseApiController
    {
        public TransactionCategoryController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpPost]
        public async Task<object> Detail(TransactionCategory.Get.Query query, CancellationToken cancellationToken)
        {
            var result = await this.Mediator.Send(query, cancellationToken);
            return result;
        }

        [HttpPost]
        public async Task<object> Create(TransactionCategory.Create.Command command, CancellationToken cancellationToken)
        {
            var result = await this.Mediator.Send(command, cancellationToken);
            return result;
        }

        [HttpPost]
        public async Task<object> Update(TransactionCategory.Update.Command command, CancellationToken cancellationToken)
        {
            var result = await this.Mediator.Send(command, cancellationToken);
            return result;
        }

        [HttpPost]
        public async Task<object> Delete([FromBody] TransactionCategory.Delete.Command command, CancellationToken cancellationToken)
        {
            var result = await this.Mediator.Send(command, cancellationToken);
            return result;
        }
    }
}