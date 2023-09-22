//using ecommerce.Domain.Base;
//using Nest;
//using System.Linq.Expressions;
//using tables.Base.Entity;

//namespace Repositories.Base
//{
//    public static class ExtensionMethod
//    {

//        public static IOrderedQueryable<T> Sort<T>(this IQueryable<T> entity, string? sortType, Func<string, Expression<Func<T, object>>> switcher) where T : BaseEntity
//        {

//            if (sortType == null || sortType.Equals("")) return entity.OrderBy(x => x.DateCreated);                                    
            
//            List<string> strings = sortType.Split(',').ToList();
//            IOrderedQueryable<T> OrderedData = null;
//            foreach (string item in strings)
//            {
//                bool isDes = item.StartsWith("-");
//                Expression<Func<T, object>> x = switcher(isDes ? item.Substring(1) : item);
//                if (item.Equals(strings.First()))
//                {
//                    OrderedData = entity.SortBy(x, isDes);
//                }
//                else
//                {

//                    OrderedData = OrderedData.SortThenBy(x, isDes);
//                }

//            }
//            return OrderedData;

//        }


      

//    }
//}
