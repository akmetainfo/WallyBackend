using System;
using System.Linq;

namespace MetaInfoRu.Common
{
    public static class PagedQueryExtensions
    {
        public static IQueryable<TSource> Paging<TSource, TRequest>(this IQueryable<TSource> source, TRequest request)
            where TRequest : PagedQuery
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (!request.IsPaged)
                return source;

            return source.Skip(request.PageOffset)
                         .Take(request.PageLimit);
        }
    }
}