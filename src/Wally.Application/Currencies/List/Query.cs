using MediatR;
using MetaInfoRu.Common;

namespace Usol.Wally.Application.Currencies.List
{
    public class Query : PagedQuery, IRequest<Result>
    {
        public Query(bool? paged, int? pagedOffset, int? pagedLimit)
            : base(paged, pagedOffset, pagedLimit)
        {
        }

        public static Query WithoutPaging()
        {
            return new Query(false, null, null);
        }
    }
}