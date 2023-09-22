using ecommerce.Domain.Base.Entity;
using PropertyEntity=ecommerce.Domain.Entities.Property.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerce.Domain.Entities.Property;

namespace ecommerce.Domain.Entities.Product;

public class ProductProperty : BaseEntityWithoutId
{

    public ProductId ProductId { get; set; }
    public PropertyId PropertyId { get; set; }


    public virtual Product Product { get; set; }

    public virtual PropertyEntity Property { get; set; }

}

