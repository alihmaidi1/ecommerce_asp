using Common.Features.Image.Commands.Models;
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
                .Must(x=>x.ContentType.Equals("image/png")||
                         x.ContentType.Equals("image/jpg")||
                         x.ContentType.Equals("image/jpeg"));



        }

    }
}
