using BrandEntity=ecommerce.Domain.Entities.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerce.Dto.Results.Admin.Brand;

namespace Repositories.Brand.Store
{
    public static class BrandStore
    {


        public static class Query{



            public static Func<BrandEntity, AddBrandResponse> ToBrandResponse = b => new AddBrandResponse()
            {

                Id = b.Id,
                Name = b.Name,
                hash = b.Hash,
                Url = b.Url,
                ResizeUrl=b.ResizedUrl
                

            };




        


       }
            




    }
}
