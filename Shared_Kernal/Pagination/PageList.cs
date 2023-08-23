using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Pagination
{
    public class PageList<T>
    {

        public PageList(List<T> items,  int count, int? pageNumber=null, int ?pageSize=null)
        {

            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            Data    = items;


        }
        public int? CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int? PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public List<T> Data { get; private set; }

    }
}
