﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;

namespace ecommerce.Domain.Entities
{
    internal class City: BaseEntity
    {

        public string Name { get; set; }
        public Country Country { get; set; }

        public float Delivery_Price { get; set; }    

    }
}
