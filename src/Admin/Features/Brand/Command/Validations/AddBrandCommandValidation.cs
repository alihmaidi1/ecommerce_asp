using ecommerce.models.SuperAdmin.Brand.Commands;
using ecommerce_shared.File.S3;
using FluentValidation;
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
        public AddBrandCommandValidation(IStorageService StorageService,IConfiguration configration) {

            string S3Url = configration.GetRequiredSection("S3")["url"];
            ApplyNameValidation();
            ApplyImageValidation(StorageService,S3Url);

        }


        public void ApplyNameValidation()
        {
         
            RuleFor(x=>x.Name)
                .NotEmpty()
                .NotNull();

        }


        public void ApplyImageValidation(IStorageService StorageService, string S3url)
        {


            RuleFor(x=>x.Image)
                .NotNull()
                .Must(x=>x.StartsWith(S3url))
                .NotEmpty()
                .Must(x=> StorageService.CheckObjectExists(x).Result);

        }
    }
}
