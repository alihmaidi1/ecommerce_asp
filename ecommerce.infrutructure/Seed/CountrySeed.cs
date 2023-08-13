using ecommerce.Domain.Entities;
using ecommerce.infrutructure.Dto;
using ecommerce.infrutructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infrutructure.Seed
{
    public static class CountrySeed
    {



        public static async Task seedData(ApplicationDbContext context,IExternalRegionApi ExternalRegionApi)
        {


            ExternalRegionDto response=await ExternalRegionApi.GetAllCountry();
            


        }

    }
}
