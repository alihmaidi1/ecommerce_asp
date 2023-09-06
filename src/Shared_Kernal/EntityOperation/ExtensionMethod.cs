
namespace ecommerce_shared.Pagination
{
    public static class ExtensionMethod
    {

        public static  async Task<PageList<T>> ToPagedList<T>(this IQueryable<T> source, int? pageNumber, int? pageSize)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if(pageSize is null)
            {

                return new PageList<T>(source.ToList(), source.ToList().Count);

            }
            int PaginatePageNumber =(int) ((pageNumber == null || pageNumber <= 0) ? 1 : pageNumber);
            int PaginatePageSize= (int) ((pageSize<=0) ? 10 : pageSize); 
            var count = source.Count();
            var items = source.Skip(((PaginatePageNumber - 1) * PaginatePageSize)).Take(PaginatePageSize).ToList();
            return new PageList<T>(items.ToList(), count, PaginatePageNumber, pageSize);
        }





    }
}
