using BrandEntity=ecommerce.Domain.Entities.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerce.Dto.Results.Admin.Brand;
using System.Linq.Expressions;

namespace Repositories.Brand.Store
{
    public static class BrandQuery
    {

        public static Expression<Func<BrandEntity, AddBrandResponse>> ToBrandResponse = b => new AddBrandResponse()
        {

            Id = b.Id,
            Name = b.Name,
            CreatedAt=b.DateCreated,
            
            image = new ecommerce_shared.File.ImageResponse()
            {

                hash = b.Hash,
                resized = b.ResizedUrl,
                Url = b.Url

            }

        };









    }
}
