using ecommerce.infrutructure.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infrutructure.Services.Interfaces
{
    public interface IExternalRegionApi
    {
        public Task<ExternalRegionDto<List<CountriesDto>>> GetAllCountry();

        public Task<ExternalRegionDto<List<GetAllCountriesWithCities>>> GetAllCountriesWithCities();

    }
}
