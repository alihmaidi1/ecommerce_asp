
using ecommerce.Domain.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;

namespace ecommerce.Domain.Entities.Brand
{
    public  class Brand :BaseEntity
    {

        public Brand()
        {

            Products=new HashSet<Product>();    

        }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Hash { get; set; }
        public string ResizedUrl { get; set; }


        public virtual ICollection<Product> Products { get; set; }


    }
}
