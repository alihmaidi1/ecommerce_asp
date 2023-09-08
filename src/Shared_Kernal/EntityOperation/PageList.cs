﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Pagination
{
    public class PageList<T>
    {

        public PageList(List<T> items,  long count, int? pageNumber=null, int ?pageSize=null)
        {

            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            Data    = items;
            var x = (count / (double)pageSize);
            TotalPages = Math.Ceiling((decimal)x);


        }
        public int? CurrentPage { get; private set; }
        public decimal TotalPages { get; private set; }
        public int? PageSize { get; private set; }
        public long TotalCount { get; private set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public List<T> Data { get; private set; }

    }
}
