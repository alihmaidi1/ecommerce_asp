//using ecommerce.models.SuperAdmin.Country;
//using FluentValidation;
//using Repositories.Country;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ecommerce.superadmin.Country.Command.Validation
//{
//    public class UnActiveCountryCommandValidation:AbstractValidator<UnActiveCountryCommand>
//    {

//        public UnActiveCountryCommandValidation(ICountryRepository CountryRepository) { 
        
//            RuleFor(x=>x.Id)
//                .NotEmpty()
//                .NotNull()
//                .Must(id=> CountryRepository.IsExists(id));    

//        }

//    }
//}
