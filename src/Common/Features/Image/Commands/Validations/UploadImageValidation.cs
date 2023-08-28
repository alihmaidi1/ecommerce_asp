using Common.Features.Image.Commands.Models;
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
        
            RuleFor(x=>x.Image).NotEmpty(); 

            RuleFor(x=>x.Image.ContentType)
                .NotEmpty()
                .WithMessage("image can not be empty")
                .Must(x=>x.Equals("image/jpeg")||x.Equals("image/jpg")||x.Equals("image/png"))
                .WithMessage("this type is not allowed")
                ;
                
        }

    }
}
