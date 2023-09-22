using ecommerce.Domain.Base.Interfaces;
using ProductEntity=ecommerce.Domain.Entities.Product.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;

namespace ecommerce.Domain.Entities.Brand
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
