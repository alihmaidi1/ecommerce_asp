using ecommerce.models.SuperAdmin.Brand.Commands;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Repositories.Brand;

namespace ecommerce.admin.Features.Brand.Command.Validations
{
    public class UpdateBrandCommandValidation:AbstractValidator<UpdateBrandCommand>
    {
        public UpdateBrandCommandValidation(IBrandRepository BrandRepository,IHttpContextAccessor httpContextAccessor) {

            
            ApplyIdValidation(BrandRepository);
            ApplyNameValidation(BrandRepository);
            ApplyLogoValidation(BrandRepository);

        }


        public void ApplyLogoValidation(IBrandRepository BrandRepository)
        {

            RuleFor(x => x)
                
                .Must(x => BrandRepository.IsValidLogo(x.Id,x.Logo))
                .OverridePropertyName("logo");
                

        }

        public void ApplyNameValidation(IBrandRepository BrandRepository)
        {

            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("name can not be empty")
                .NotNull()
                .WithMessage("name can not be null")
                .Must(x=>BrandRepository.IsUniqueName(x.Id,x.Name))
                .OverridePropertyName("name")
                .WithMessage("name is already exists in our database");


        }

        public void ApplyIdValidation(IBrandRepository BrandRepository)
        {


            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("id can not be empty")
                .NotNull()
                .WithMessage("id can not be null")
                .Must(x=>BrandRepository.IsExists(x))
                .WithMessage("this brand is not exists in our data");


        }


    }
}
