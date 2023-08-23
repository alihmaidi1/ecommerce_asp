using ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infrutructure.Dto
{
    public class CountriesDto
    {



        public string Name { get; set; }
        public string Iso2 { get; set; }
        public double Lat { get; set; }


        public static Func<CountriesDto, Country> ToCountryDto = c => new Country
        {
            Name=c.Name,
            lat=c.Lat,
            Code=c.Iso2


        };





    }




}
