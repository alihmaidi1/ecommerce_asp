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
        public static IQueryable<T> SortBy<T,Tkey>(this IQueryable<T> source,Expression<Func<T,Tkey>> by,bool? isDes) 

            =>(!isDes.HasValue||isDes.Value)?source.OrderByDescending(by)
                                            :source.OrderBy(by);
    }
}
