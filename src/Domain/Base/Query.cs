using Amazon.Auth.AccessControlPolicy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.Base
{
    public static class Query
    {
        public static IOrderedQueryable<T> SortThenBy<T,Tkey>(this IOrderedQueryable<T> source,Expression<Func<T,Tkey>> by,bool? isDes=false) 

            =>(!isDes.HasValue||isDes.Value)?source?.ThenByDescending(by)
                                            :source?.ThenBy(by);

        public static IOrderedQueryable<T> SortBy<T, Tkey>(this IQueryable<T> source, Expression<Func<T, Tkey>> by, bool? isDes = false)

            => (!isDes.HasValue || isDes.Value) ? source?.OrderByDescending(by)
                                            : source?.OrderBy(by);


    }
}
