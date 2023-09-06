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
            ApplyLogoValidation();

        }


        public void ApplyLogoValidation()
        {

            RuleFor(x => x.Logo)
                .NotEmpty()
                .WithMessage("Logo can not be empty")
                .NotNull()
                .WithMessage("Logo can not be null");


        }

        public void ApplyNameValidation(IBrandRepository BrandRepository)
        {

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("name can not be empty")
                .NotNull()
                .WithMessage("name can not be null")
                .Must(x=>BrandRepository.IsUniqueName(x))
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
