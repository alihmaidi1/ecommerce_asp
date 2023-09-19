using ecommerce.models.SuperAdmin.Category.Command;
using ecommerce_shared.Rule;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Repositories.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.superadmin.Category.Command.Validation
{
    public class StoreCategoryCommandValidation:AbstractValidator<StoreCategoryCommand>
    {


        public StoreCategoryCommandValidation(IWebHostEnvironment webHost,ICategoryRepository CategoryRepository) { 
        
            RuleFor(x=>x.Name)
                .NotEmpty()
                .NotNull()
                .Must(name=>CategoryRepository.IsUniqueName(name));

            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Meta_Title)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Rank)
                .NotNull()
                .NotEmpty()
                .Must(rank=>CategoryRepository.IsUniqueRank(rank));

            
            RuleFor(x => x.Meta_Description)
                .NotEmpty()
                .NotNull();


            RuleFor(x => x.ParentId)
                .Must(parentid=>CategoryRepository.IsExists(parentid));
            
            RuleForEach(x => x.Tags)
                .NotEmpty()
                .NotNull();

            RuleForEach(x => x.Images)
                .NotNull()
                .NotEmpty()
                .Must(x=>FileRule.isFileExists(x, webHost.WebRootPath));


        }


    }
}
