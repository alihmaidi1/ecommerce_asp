using ecommerce.Domain.Base.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.Entities.Country
{
    public class CountryId : StronglyTypeId
    {
        public CountryId(Guid Value) : base(Value)
        {
        }
    }
}
