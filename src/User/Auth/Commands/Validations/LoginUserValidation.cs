//using ecommerce.models.Users.Auth.Commands;
//using FluentValidation;
//using Repositories.User;

//namespace ecommerce.user.Auth.Commands.Validations
//{
//    public class LoginUserValidation : AbstractValidator<LoginUserCommand>
//    {


//        public LoginUserValidation(IUserRepository UserRepository)
//        {

//            ApplyUserNameOrEmailValidation(UserRepository);
//            ApplyPasswordValiation();

//        }


//        public void ApplyUserNameOrEmailValidation(IUserRepository UserRepository)
//        {

//            RuleFor(x => x.UserName)
//                .NotNull()
//                .WithMessage("UserName Or Email Can not be null")
//                .NotEmpty()
//                .WithMessage("UserName Or Email Can not be empty")
//                .Must(x=>UserRepository.IsLocalUserNameExists(x))
//                .WithMessage("this username is not register loacally or not exists");
//        }


//        public void ApplyPasswordValiation()
//        {

//            RuleFor(x => x.Password)
//                .NotEmpty()
//                .WithMessage("password should be empty")
//                .NotNull()
//                .WithMessage("password should be null");
//        }


//    }
//}
