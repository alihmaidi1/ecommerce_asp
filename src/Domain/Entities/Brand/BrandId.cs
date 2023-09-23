using ecommerce.Domain.Base.ValueObject;
using ecommerce.Domain.Entities.Slider;
using Newtonsoft.Json.Linq;
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

        public static implicit operator Guid(BrandId StronglyId) => StronglyId.Value;
        public static implicit operator BrandId(Guid value) => new BrandId(value);

        
    }
}
