using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Dto.Results.User.City.Query
{
    public class OnlyCityDto
    {


        public Guid Id { get; set; }

        public string Name { get; set; }
        
        public bool status { get; set; }

        public float Delivery_Price { get; set; }


    }
}
