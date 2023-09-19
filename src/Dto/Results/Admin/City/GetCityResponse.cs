using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Dto.Results.Admin.City
{
    public class GetCityResponse
    {


        public Guid Id { get; set; }
        public string Name { get; set; }
        
        
        public Boolean status { get; set; }

        public float Delivery_Price { get; set; }



    }
}
