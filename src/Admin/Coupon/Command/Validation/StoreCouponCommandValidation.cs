using ecommerce.Domain.Enum;
using ecommerce.models.SuperAdmin.Coupon;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.superadmin.Coupon.Command.Validation
{
    public class StoreCouponCommandValidation:AbstractValidator<StoreCouponCommand>
    {

        public StoreCouponCommandValidation()
        {

            RuleFor(x=>x.EndAt)
                .NotEmpty()
                .NotNull()
                .GreaterThan(DateTime.Now);

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Value)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.Type)
                .NotEmpty()
                .NotNull();

            RuleFor(x=>x)
                .Must(x=>!(x.Type==CoponType.PRECENT&&x.Value>100));

        }

    }
}
