using ecommerce.Domain.Base.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.Entities.Product
{
    public class ProductId : StronglyTypeId
    {
        public ProductId(Guid Value) : base(Value)
        {
        }
    }
}
