//using ecommerce.Domain.Entities.Identity;
//using ecommerce.models.Users.Auth.Commands;
//using FluentValidation;
//using Microsoft.AspNetCore.Identity;
//using Repositories.User;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ecommerce.user.Auth.Commands.Validations
//{
//    public class ConfirmAccountValidation : AbstractValidator<ConfirmAccountCommand>
//    {

//        public ConfirmAccountValidation(IUserRepository UserRepository)
//        {

//            ApplyEmailValidation(UserRepository);
//            ApplyCodeValidation();

//        }

//        public void ApplyCodeValidation()
//        {

//            RuleFor(x => x.Code)
//                .NotEmpty()
//                .WithMessage("the code can not be empty")
//                .NotNull()
//                .WithMessage("the code can not be null")
//                ;
//        }


//        public void ApplyEmailValidation(IUserRepository UserRepository)
//        {

//            RuleFor(x => x.Email)
//                .NotEmpty()
//                .WithMessage("the email can not be empty")
//                .NotNull()
//                .WithMessage("the email code can not be empty")
//                .Must(x=>UserRepository.IsEmailConfirmed(x))
//                .WithMessage("this email is not exists or already confirmed");

//        }
//    }
//}
