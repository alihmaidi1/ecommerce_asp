using ecommerce.Domain.Base.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.Entities.Currency
{
    public class CurrencyId : StronglyTypeId
    {
        public CurrencyId(Guid Value) : base(Value)
        {
        }
    }
}
