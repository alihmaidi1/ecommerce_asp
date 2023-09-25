using ecommerce.models.SuperAdmin.Country;
using ecommerce.models.SuperAdmin.Coupon;
using ecommerce_shared.OperationResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.superadmin.Coupon.Command.Handlers
{
    public class CouponHandlers : OperationResult,
        IRequestHandler<StoreCouponCommand, JsonResult>
    {
        public Task<JsonResult> Handle(StoreCouponCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
