using ecommerce.Domain.Base.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.Entities.Coupon
{
    public class CouponId : StronglyTypeId
    {
        public CouponId(Guid Value) : base(Value)
        {
        }
    }
}
