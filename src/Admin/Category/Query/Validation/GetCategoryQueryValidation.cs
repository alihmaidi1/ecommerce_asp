//using ecommerce.models.SuperAdmin.Category.Query;
//using FluentValidation;
//using Microsoft.AspNetCore.Mvc;
//using Repositories.Category;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ecommerce.superadmin.Category.Query.Validation
//{
//    public class GetCategoryQueryValidation:AbstractValidator<GetCategoryQuery>
//    {

//        public GetCategoryQueryValidation(ICategoryRepository CategoryRepository) {


//            RuleFor(x => x.Id)
//                .NotEmpty()
//                .NotNull()
//                .Must(x => CategoryRepository.IsExists(x));

        
//        }

//    }
//}
