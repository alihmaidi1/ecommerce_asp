using Common.Features.Image.Commands.Models;
using ecommerce_shared.File;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Features.Image.Commands.Validations
{
    public class UploadBase64ImageValidation:AbstractValidator<UploadBase64ImageCommand>
    {

        public UploadBase64ImageValidation() {


            RuleFor(x => x.Image).Must(x => x.IsBase64Image());
        
        }
    }
}
