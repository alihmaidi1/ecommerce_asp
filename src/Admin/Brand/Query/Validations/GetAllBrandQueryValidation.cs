using ecommerce.models.SuperAdmin.Brand.Query;
using ecommerce_shared.Rule;
using FluentValidation;
using Repositories.Brand.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Features.Brand.Query.Validations
{
    public class GetAllBrandQueryValidation:AbstractValidator<GetAllBrandQuery>
    {


        public GetAllBrandQueryValidation() {


            RuleFor(x => x.OrderBy)
                .Must(x=>CrudOpterationRule.IsValidOrder(x,BrandSorting.OrderBy))
                .WithMessage("order by is not valid");

        }


    }
}
