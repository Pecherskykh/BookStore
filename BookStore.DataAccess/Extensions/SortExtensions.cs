using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BookStore.DataAccess.Extensions
{
    public static class SortExtensions
    {
        public static IQueryable<TSource> OrderDirection<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, bool lowToHigh)
        {
            if (lowToHigh)
            {
                return source.OrderBy(keySelector);
            }
            return source.OrderByDescending(keySelector);
        }
    }
}
