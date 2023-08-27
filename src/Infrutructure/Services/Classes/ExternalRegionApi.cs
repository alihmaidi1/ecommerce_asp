using ecommerce.Dto;
using ecommerce.infrutructure.Services.Interfaces;
using System.Net.Http.Json;

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
