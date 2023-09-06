using ecommerce.Domain.Entities.Identity;
using ecommerce.models.Users.Auth.Commands;
using ecommerce_shared.Rule;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Repositories.City;
using Repositories.User;

namespace ecommerce.user.Auth.Commands.Validations
{
    public class AddUserValidation : AbstractValidator<AddUserCommand>
    {

        public AddUserValidation(IUserRepository UserRepository,ICityRepository CityRepository,IWebHostEnvironment webhost)
        {

            

            
            ApplyUserNameValidation(UserRepository);
            ApplyPasswordValidation();
            ApplyEmailValidation(UserRepository);
            ApplyNameValidation();
            ApplyCityValidation(CityRepository);
            ApplyDateOfBirthValidation();
            ApplyLogoValidation(webhost.WebRootPath);

        }

        public void ApplyUserNameValidation(IUserRepository UserRepository)
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("username should be not empty")
                .NotNull()
                .WithMessage("username should be not null")
                .Must(x=>!UserRepository.IsUserNameExists(x))
                .WithMessage("UserName Is Already Exists")
                ;



        }

        public void ApplyPasswordValidation()
        {

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("password should be not empty")

                .NotNull()
                .WithMessage("password should be not null");


        }



        public void ApplyEmailValidation(IUserRepository UserRepository)
        {

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("email should be not empty")

                .NotNull()
                .WithMessage("email should be not null")

                .EmailAddress()
                .WithMessage("email should be email address")
                .Must(x=>!UserRepository.CheckEmailExists(x).Result)
                .WithMessage("this email is already register")

                ;


        }



        public void ApplyNameValidation()
        {

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("name should be not empty")

                .NotNull()
                .WithMessage("name should be not empty")

                ;

        }

        public void ApplyDateOfBirthValidation()
        {



        }

        public void ApplyCityValidation(ICityRepository CityRepository)
        {
            RuleFor(x => x.CityId)
                .NotEmpty()
                .WithMessage("city id should be not empty")

                .NotNull()
                .WithMessage("city id should be not null")
                .Must(x=>CityRepository.IsCityIdExists(x))
                .WithMessage("this city is not exists");

        }


        public void ApplyLogoValidation(string wwwroot)
        {

            RuleFor(x => x.Logo)
                .Must(x => FileRule.isFileExists(x, wwwroot))
                .WithMessage("this image is not exists in our data");


        }

    }
}
