using ecommerce.Domain.Base.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.Entities.Brand
{
    public class BrandId : StronglyTypeId
    {
        public BrandId(Guid Value) : base(Value)
        {




        }
    }
}
