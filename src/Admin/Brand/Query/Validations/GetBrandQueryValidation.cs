using ecommerce.models.SuperAdmin.Brand.Query;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Repositories.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.superadmin.Brand.Query.Validations
{
    public class GetBrandQueryValidation:AbstractValidator<GetBrandQuery>
    {

        public GetBrandQueryValidation(IBrandRepository BrandRepository) {

            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .Must(x=> BrandRepository.IsExists(x));
                
        
        }

    }
}
