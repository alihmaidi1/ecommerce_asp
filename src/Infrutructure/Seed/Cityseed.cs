using ecommerce.Domain.Entities;
using ecommerce.Dto;
using ecommerce.infrutructure.Services.Interfaces;
using EFCore.BulkExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infrutructure.Seed
{
    public static class Cityseed
    {

        public static async Task seedData(ApplicationDbContext context, IExternalRegionApi ExternalRegionApi)
        {


            if (!context.Cities.Any())
            {

                ExternalRegionDto<List<GetAllCountriesWithCities>> response = await ExternalRegionApi.GetAllCountriesWithCities();
                List<Country> Countries = context.Countries.Select(Country.SelectIDAndName).ToList();
                List<City> data = response.data.SelectMany(x => x.ToListOfCities(x, Countries)).ToList();
                context.AddRange(data); ;                
                context.SaveChanges();

            }


        }

    }
}
