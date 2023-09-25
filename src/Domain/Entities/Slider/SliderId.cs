using ecommerce.Domain.Base.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.Entities.Slider
{
    public class SliderId : StronglyTypeId
    {
        public SliderId(Guid Value) : base(Value)
        {

        }

        public static implicit operator Guid(SliderId StronglyId) => StronglyId.Value;
        public static implicit operator SliderId(Guid value) => new SliderId(value);

    }
}
