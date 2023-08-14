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

            int CountryCount=context.Countries.Count();
            if (CountryCount == 0)
            {

                ExternalRegionDto<List<CountriesDto>> response = await ExternalRegionApi.GetAllCountry();
                List<Country> countries = response.data.Select(c=>c.ToCountryDto()).ToList();
                context.AddRange(countries);
                context.SaveChanges();
                                
                

            }

        }

    }

    public class Country1
    {

        public string name { get; set; }
            public string iso2 { get; set; }    

            public string lat { get; set; }
    }
}
