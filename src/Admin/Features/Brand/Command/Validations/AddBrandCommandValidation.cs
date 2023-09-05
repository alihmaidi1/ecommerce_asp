using ecommerce.models.SuperAdmin.Brand.Commands;
using ecommerce_shared.Constant;
using ecommerce_shared.File;
using ecommerce_shared.File.S3;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Features.Brand.Command.Validations
{
    public class AddBrandCommandValidation:AbstractValidator<AddBrandCommand>
    {
        public AddBrandCommandValidation(IWebHostEnvironment WebHostEnvironment, IConfiguration configration) {

            string host = configration.GetValue<string>("host");
            string wwwroot = WebHostEnvironment.WebRootPath;
            ApplyNameValidation();
            ApplyImageValidation( host, wwwroot);

        }


        public void ApplyNameValidation()
        {
         
            RuleFor(x=>x.Name)
                .NotEmpty()
                .NotNull();

        }


        public void ApplyImageValidation(string host,string wwwroot)
        {


            RuleFor(x=>x.Image)
                .NotNull()
                .Must(x=>x.StartsWith(host))
                .NotEmpty()
                .Must(x=> FileExtensionLocal.IsImageExists(x,host,wwwroot));

        }
    }
}
