using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;

namespace ecommerce.Domain.Entities
{
    public class City: BaseEntity
    {

        public string Name { get; set; }
        public Country Country { get; set; }

        [Range(0,Double.MaxValue)]
        public float Delivery_Price { get; set; }    


    }
}
