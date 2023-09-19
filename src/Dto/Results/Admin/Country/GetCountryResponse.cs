using ecommerce.Dto.Results.Admin.City;
using ecommerce.Dto.Results.User.City.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Dto.Results.Admin.Country
{
    public class GetCountryResponse
    {


        public Guid Id { get; set; }


        public string Name { get; set; }
        public string Code { get; set; }

        public double lat { get; set; }

        public bool Status { get; set; }


        public List<OnlyCityDto> Cities { get; set; }


    }
}
