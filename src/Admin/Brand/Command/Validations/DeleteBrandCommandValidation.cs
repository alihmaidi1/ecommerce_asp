//using ecommerce.models.SuperAdmin.Brand.Commands;
//using FluentValidation;
//using Repositories.Brand;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ecommerce.admin.Brand.Command.Validations
//{
//    public class DeleteBrandCommandValidation : AbstractValidator<DeletebrandCommand>
//    {

//        public DeleteBrandCommandValidation(IBrandRepository BrandRepository)
//        {

//            RuleFor(x => x.Id)
//                .NotEmpty()
//                .WithMessage("brand id can not be empty")
//                .NotNull()
//                .WithMessage("brand id can not be null")
//                .Must(x => BrandRepository.IsExists(x))
//                .WithMessage("this brand is not exists in our database");

//        }
//    }
//}
