using ecommerce.Domain.Base.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.Entities.Property
{
    public class PropertyId : StronglyTypeId
    {
        public PropertyId(Guid Value) : base(Value)
        {
        }
    }
}
