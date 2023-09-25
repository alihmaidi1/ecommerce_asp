using ProductEntity=ecommerce.Domain.Entities.Product.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;

namespace ecommerce.Domain.Entities.Property
{
    public class Property : BaseEntity<PropertyId>
    {

        public Property()
        {

            Products = new HashSet<ProductEntity>();
            Id = new PropertyId(Guid.NewGuid());

        }

        public string Name { get; set; }

        public virtual ICollection<ProductEntity> Products { get; set; }

    }
}
