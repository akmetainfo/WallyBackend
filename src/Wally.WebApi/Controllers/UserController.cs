using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Users = Usol.Wally.Application.Users;

namespace Usol.Wally.WebApi.Controllers
{
    public class UserController : BaseApiController
    {
        public UserController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpPost]
        public async Task<object> List(Users.List.Query query, CancellationToken cancellationToken)
        {
            var result = await this.Mediator.Send(query, cancellationToken);
            return result;
        }
    }
}