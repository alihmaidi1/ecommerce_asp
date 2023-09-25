using ecommerce.Domain.Enum;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.models.SuperAdmin.Coupon
{
    public class StoreCouponCommand:IRequest<JsonResult>
    {

        public string Name { get; set; }
        public CoponType Type { get; set; }

        public float Value { get; set; }


        public DateTime EndAt { get; set; }






    }
}
