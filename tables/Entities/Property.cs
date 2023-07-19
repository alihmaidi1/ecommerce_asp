﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;

namespace ecommerce.Domain.Entities
{
    public class Property: BaseEntity
    {

        public Property()
        {

            Products=new HashSet<ProductProperty>();   

        }

        public string Name { get; set; }

        public ICollection<ProductProperty> Products{ get; set; }

    }
}
