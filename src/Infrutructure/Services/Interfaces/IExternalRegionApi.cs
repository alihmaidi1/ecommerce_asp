using ecommerce.Dto;

namespace ecommerce.infrutructure.Services.Interfaces
{
    public interface IExternalRegionApi
    {
        public Task<ExternalRegionDto<List<CountriesDto>>> GetAllCountry();

        public Task<ExternalRegionDto<List<GetAllCountriesWithCities>>> GetAllCountriesWithCities();

    }
}
