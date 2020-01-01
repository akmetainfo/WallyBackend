using MediatR;
using MetaInfoRu.Common;

namespace Usol.Wally.Application.Users.List
{
    public class Query : PagedQuery, IRequest<Result>
    {
        public Query(bool? paged, int? pagedOffset, int? pagedLimit)
            : base(paged, pagedOffset, pagedLimit)
        {
        }
    }
}