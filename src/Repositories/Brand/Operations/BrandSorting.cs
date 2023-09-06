using BrandEntity=ecommerce.Domain.Entities.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ecommerce.Dto.Results.Admin.Brand;
using ecommerce.Domain.Base;

namespace Repositories.Brand.Operations
{
    public static class BrandSorting
    {

        public static List<string> OrderBy = new List<string>()
        {
            "Name"

        };


        public static IQueryable<BrandEntity> Sort(this IQueryable<BrandEntity> brand, string? sortType,bool? isDes)
        {

            if (sortType == null)

                return brand.SortBy(x=>x.DateCreated,isDes);

            return sortType switch
            {


                "Name"=> brand.SortBy(x => x.Name,isDes),
                _=> brand.SortBy(x => x.DateCreated,isDes)
                
            };



        }
        
    }


    
}
