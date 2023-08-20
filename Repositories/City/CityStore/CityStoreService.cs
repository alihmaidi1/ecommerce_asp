using ecommerce.Domain.Entities;
using ecommerce.Dto.Results.User.City.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.City.CityStore
{
    public class CityStoreService
    {

        public static class Query
        {

            public static Func<ecommerce.Domain.Entities.City, OnlyCityDto> ToCityName = city => new OnlyCityDto
            {

                Name= city.Name,
                Id= city.Id,
                status=city.status,
                Delivery_Price=city.Delivery_Price


            };


        }

    }
}
