using MediatR;
using MetaInfoRu.Common;

namespace Usol.Wally.Application.Accounts.List
{
    public class Query : PagedQuery, IRequest<Result>
    {
        public Query(bool? isCorrespondent, bool? isActive, string needle, bool? paged, int? pagedOffset, int? pagedLimit)
            : base(paged, pagedOffset, pagedLimit)
        {
            this.IsCorrespondent = isCorrespondent;
            this.IsActive = isActive;
            this.Needle = needle;
        }

        public static Query WithoutPaging(bool? isCorrespondent, bool? isActive, string needle)
        {
            return new Query(isCorrespondent, isActive, needle, false, null, null);
        }

        public bool? IsCorrespondent { get; }
        public bool? IsActive { get; }
        public string Needle { get; }
    }
}
