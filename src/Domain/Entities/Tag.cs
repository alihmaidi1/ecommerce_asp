﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;

namespace ecommerce.Domain.Entities
{
    public class Tag
    {


        public Guid Id { get; set; }

        public string Name { get; set; }

    }
}
