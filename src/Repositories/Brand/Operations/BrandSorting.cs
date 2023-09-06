﻿using BrandEntity=ecommerce.Domain.Entities.Brand;
using ecommerce.Domain.Base;
using System.Linq.Expressions;
using NetTopologySuite.Index.HPRtree;
using tables.Base.Entity;

namespace Repositories.Brand.Operations
{
    public static class BrandSorting
    {

        public static List<string> OrderBy = new List<string>()
        {
            "Name",
            "CreatedAt"
        };
        
        
        public static Func<string, Expression<Func<BrandEntity, object>>> switchOrdering= key
            
            =>key switch
            {

                "Name" => x => x.Name,
                _ => x => x.DateCreated,

            };
            

        

    }


    
}
