using ecommerce.models.SuperAdmin.Brand.Commands;
using ecommerce_shared.Constant;
using ecommerce_shared.File;
using ecommerce_shared.File.S3;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Repositories.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Features.Brand.Command.Validations
{
    public class AddBrandCommandValidation:AbstractValidator<AddBrandCommand>
    {
        public AddBrandCommandValidation(IWebHostEnvironment WebHostEnvironment,IBrandRepository BrandRepository)
        {

            string wwwroot = WebHostEnvironment.WebRootPath;
            ApplyNameValidation(BrandRepository);
            ApplyImageValidation(wwwroot);

        }


        public void ApplyNameValidation(IBrandRepository BrandRepository)
        {
         
            RuleFor(x=>x.Name)
                .NotEmpty()
                .WithMessage("brand name should be not empty")
                .NotNull()
                .WithMessage("brand name should be not null")
                .Must(x=> !BrandRepository.IsNameExists(x))
                .WithMessage("This Brand with this name is exists");

        }


        public void ApplyImageValidation(string wwwroot)
        {


            RuleFor(x=>x.Image)
                .NotNull()
                .WithMessage("image should be not null")
                .NotEmpty()
                .WithMessage("image should be not empty")
                .Must(x=> FileExtensionLocal.IsImageExists(x,wwwroot))
                .WithMessage("This File Is Not Exists");

        }
    }
}
