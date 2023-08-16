using ecommerce.Domain.Entities;
using ecommerce.infrutructure.Dto;
using ecommerce.infrutructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infrutructure.Services.Classes
{
    public class ExternalRegionApi : IExternalRegionApi
    {
        public HttpClient HttpClient { get; set; }
        public ExternalRegionApi(IHttpClientFactory HttpClientFactory)
        {
            this.HttpClient = HttpClientFactory.CreateClient("Region");

        }


        public async Task<ExternalRegionDto<List<CountriesDto>>> GetAllCountry()
        {
            return await HttpClient.GetFromJsonAsync<ExternalRegionDto<List<CountriesDto>>>("api/v0.1/countries/positions");

        }

        public async Task<ExternalRegionDto<List<GetAllCountriesWithCities>>> GetAllCountriesWithCities()
        {

            return await HttpClient.GetFromJsonAsync<ExternalRegionDto<List<GetAllCountriesWithCities>>>("api/v0.1/countries");

        }

    }
}
