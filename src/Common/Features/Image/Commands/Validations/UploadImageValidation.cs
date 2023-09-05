using Common.Features.Image.Commands.Models;
using ecommerce_shared.Rule;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Features.Image.Commands.Validations
{
    public class UploadImageValidation:AbstractValidator<UploadImageCommand>
    {
        public UploadImageValidation() {

            RuleFor(x => x.Image)
                .NotEmpty()
                .WithMessage("image can not be empty")
                .NotNull()
                .WithMessage("image can not be null")
                .Must(FileRule.IsFile)
                .WithMessage("this file should be image");
            

            
                
        }

    }
}
