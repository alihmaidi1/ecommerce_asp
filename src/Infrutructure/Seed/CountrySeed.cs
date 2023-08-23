using ecommerce.Domain.Entities;
using ecommerce.infrutructure.Dto;
using ecommerce.infrutructure.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace ecommerce.infrutructure.Seed
{
    public static class CountrySeed
    {



        public static async Task seedData(ApplicationDbContext context,IExternalRegionApi ExternalRegionApi)
        {

            if (!context.Countries.Any())
            {

                ExternalRegionDto<List<CountriesDto>> response = await ExternalRegionApi.GetAllCountry();
                var countries = response.data.Select(CountriesDto.ToCountryDto).ToList();
                context.Countries.BulkInsert(countries);
                context.SaveChanges();                                                
          
            }

        }

    }

}
