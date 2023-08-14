using ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infrutructure.Dto
{
    public class CountriesDto
    {



        public string Name { get; set; }
        public string Iso2 { get; set; }
        public double Lat { get; set; }


        public Country ToCountryDto()
        {
            return new Country { 

                Name = Name,
                lat = Lat,
                Code=Iso2
            
            };            
        }


    }




}
