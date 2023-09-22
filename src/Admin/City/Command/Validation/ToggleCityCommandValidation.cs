//using ecommerce.models.SuperAdmin.City.Command;
//using FluentValidation;
//using Repositories.City;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ecommerce.superadmin.City.Command.Validation
//{
//    public class ToggleCityCommandValidation:AbstractValidator<ToggleCityCommand>
//    {

//        public ToggleCityCommandValidation(ICityRepository CityRepository) { 
        

//            RuleFor(x=>x.Id)
//                .NotEmpty()
//                .NotNull()
//                .Must(x=> CityRepository.IsCityIdExists(x));
//        }

//    }
//}
