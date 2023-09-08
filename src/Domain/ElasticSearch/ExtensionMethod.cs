using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.ElasticSearch
{
    public static class ExtensionMethod
    {


        public static SortDescriptor<T> SortBy<T,Tkey>(this SortDescriptor<T> source,Expression<Func<T, Tkey>>  by, bool? isDes = false) where T : class

            => (!isDes.HasValue || isDes.Value) ? source?.Descending(by)
                                            : source?.Ascending(by);


        public static SortDescriptor<T> SortQuery<T>(this SortDescriptor<T> query, string? sortType, Func<string, Expression<Func<T, object>>> switcher) where T : class
        {

            if (sortType == null || sortType.Equals("")) return query;

            List<string> strings = sortType.Split(',').ToList();
            foreach (string item in strings)
            {
                bool isDes = item.StartsWith("-");
                Expression<Func<T, object>> x = switcher(isDes ? item.Substring(1) : item);
                query = query.SortBy(x,isDes);

            }
            return query;

        }

    }
}
