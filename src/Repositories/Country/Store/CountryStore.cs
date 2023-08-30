using CountryEntity= ecommerce.Domain.Entities.Country;
using ecommerce.Dto.Results.Admin.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Country.Store
{
    public static class CountryStore
    {

        public static class Query
        {

            public static Expression<Func<CountryEntity, GetAllCountriesDto>> ToGetAllCountryDto => c => new GetAllCountriesDto
            {
                Id = c.Id,
                Code = c.Code,
                lat = c.lat,
                Name = c.Name,
                Status = c.Status,

            };


        }

    }
}
