using ecommerce.Domain.Abstract;
using ecommerce.user.Features.Auth.Commands.Models;

using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace ecommerce.user.Features.Auth.Commands.Validations
{
    public class AddUserValidation:AbstractValidator<AddUserCommand>
    {

        public UserManager<Account> UserManager;
        public AddUserValidation(UserManager<Account> userManager) {


            this.UserManager= userManager;

            ApplyUserNameValidation();
            ApplyPasswordValidation();
            ApplyEmailValidation();
            ApplyNameValidation();
            ApplyCityValidation();
            ApplyDateOfBirthValidation();

        }
        
        public void ApplyUserNameValidation()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .NotNull();
                

        }

        public void ApplyPasswordValidation()
        {

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull();

        }



        public void ApplyEmailValidation()
        {

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress();
                

        }

        

        public void ApplyNameValidation()
        {

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull();

        }

        public void ApplyDateOfBirthValidation()
        {



        }

        public void ApplyCityValidation()
        {
            RuleFor(x => x.CityId)
                .NotEmpty()
                .NotNull();

        }
        

    }
}
