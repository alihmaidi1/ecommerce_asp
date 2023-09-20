using ecommerce.models.SuperAdmin.Category.Command;
using FluentValidation;
using Repositories.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.superadmin.Category.Command.Validation
{
    public class DeleteCategoryCommandValidation:AbstractValidator<DeleteCategoryCommand>
    {

        public DeleteCategoryCommandValidation(ICategoryRepository CategoryRepository) { 
        

            RuleFor(x=>x.Id)
                .NotEmpty()
                .NotNull()
                .Must(id=> CategoryRepository.IsExists(id));

        }

    }
}
