using System;
using System.Linq;
using System.Linq.Expressions;
using MetaInfoRu.Common.Enums;

namespace MetaInfoRu.Common.Extensions
{
    public static class QueryExtensions
    {
        public static IOrderedQueryable<TEntity> AddOrder<TEntity, TOrderKey>(this IQueryable<TEntity> query,
                                                                                 Expression<Func<TEntity, TOrderKey>> orderBy,
                                                                                 Sorted? sort)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            if (sort == null)
                return query.OrderBy(x => 0);

            return sort == Sorted.Asc
                ? query.OrderBy(orderBy)
                : query.OrderByDescending(orderBy);
        }
    }
}