using ecommerce.Domain.Base.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.Entities.City
{
    public class CityId : StronglyTypeId
    {
        public CityId(Guid Value) : base(Value)
        {
        }
    }
}
