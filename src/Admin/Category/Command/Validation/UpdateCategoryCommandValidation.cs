//using ecommerce.models.SuperAdmin.Category.Command;
//using ecommerce_shared.Rule;
//using FluentValidation;
//using Microsoft.AspNetCore.Hosting;
//using Repositories.Category;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ecommerce.superadmin.Category.Command.Validation
//{
//    public class UpdateCategoryCommandValidation:AbstractValidator<UpdateCategoryCommand>
//    {

//        public UpdateCategoryCommandValidation(ICategoryRepository CategoryRepository,IWebHostEnvironment WebHostEnvironment) {
        

//            RuleFor(x=>x.Id)
//                .NotEmpty()
//                .NotNull()
//                .Must(id=> CategoryRepository.IsExists(id));

//            RuleFor(x => x)
//                .NotNull()
//                .NotEmpty()
//                .Must(x=>CategoryRepository.IsUniqueName(x.Name,x.Id))
//                .OverridePropertyName("Name");
            
            
//            RuleFor(x => x)
//                .NotNull()
//                .NotEmpty()
//                .Must(x=>CategoryRepository.IsUniqueRank(x.Rank,x.Id))
//                .OverridePropertyName("Rank");

//            RuleFor(x => x.Meta_Title)
//                .NotEmpty()
//                .NotNull();

//            RuleFor(x => x.Description)
//                .NotNull()
//                .NotEmpty();

//            RuleFor(x => x.Meta_Description)
//                .NotEmpty()
//                .NotNull();

//            RuleFor(x => x.ParentId)
//                .Must(x=>CategoryRepository.IsExists(x));

            
//            RuleForEach(x => x.Images)
//                .NotEmpty()
//                .NotNull()
//                .Must(image=>FileRule.isFileExists(image, WebHostEnvironment.WebRootPath));

//            RuleFor(x => x)
//                .Must(x=>CategoryRepository.ValidImages(x.DeletedImages,x.Id))
//                .OverridePropertyName("deletedImages");

//        }

//    }
//}
