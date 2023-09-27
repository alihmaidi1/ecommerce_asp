<<<<<<<< HEAD:src/Domain/Entities/Brand/Brand.cs
﻿using ecommerce.Domain.Base.Interfaces;
using ProductEntity=ecommerce.Domain.Entities.Product.Product;
========
using ecommerce.Domain.Base.Interfaces;
>>>>>>>> ed:src/Domain/Entities/BrandEntities/Brand.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;

<<<<<<<< HEAD:src/Domain/Entities/Brand/Brand.cs
namespace ecommerce.Domain.Entities.Brand
========
namespace ecommerce.Domain.Entities.BrandEntities
>>>>>>>> ed:src/Domain/Entities/BrandEntities/Brand.cs
{
    public class Brand : BaseEntity<BrandId>
    {

        public Brand()
        {

            Products = new HashSet<ProductEntity>();
            Id=new BrandId(Guid.NewGuid());

        }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Hash { get; set; }
        public string ResizedUrl { get; set; }

        public virtual ICollection<ProductEntity> Products { get; set; }


    }
}