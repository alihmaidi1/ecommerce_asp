using ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Dto.Results.Admin.Country
{
    public class GetAllCountriesDto
    {


        public Guid Id { get; set; }


        public string Name { get; set; }
        public string Code { get; set; }

        public double lat { get; set; }

        
        public bool Status { get; set; }



    }
}
