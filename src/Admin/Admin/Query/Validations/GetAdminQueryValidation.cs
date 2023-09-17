using Amazon.Runtime.Internal;
using ecommerce.models.SuperAdmin.Admin.Query;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.superadmin.Admin.Query.Validations
{
    public class GetAdminQueryValidation:AbstractValidator<GetAdminQuery>
    {

        public GetAdminQueryValidation()
        {

            RuleFor(x=>x.Id)
                .NotEmpty()
                .NotNull();


        }

    }
}
