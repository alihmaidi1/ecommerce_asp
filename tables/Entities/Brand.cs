﻿using ecommerce.Domain.Base.Entity;
using ecommerce.Domain.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;

namespace ecommerce.Domain.Entities
{
    public  class Brand : Imagable
    {

        public Brand()
        {

            Products=new HashSet<Product>();    

        }
        public string Name { get; set; }
        public Image Url { get; set; }

        public ICollection<Product> Products { get; set; }


    }
}
