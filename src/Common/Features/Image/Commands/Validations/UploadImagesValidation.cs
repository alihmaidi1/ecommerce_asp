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
    public class UploadImagesValidation:AbstractValidator<UploadImagesCommand>
    {

        public UploadImagesValidation() {


            RuleForEach(x=>x.images)
                .NotNull()
                .WithMessage("image can not be null")
                .NotEmpty()
                .WithMessage("image can not be empty")
                .Must(FileRule.IsFile)
                .WithMessage("image extension should be png,jpg,jpeg");



        }

    }
}
