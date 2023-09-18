using ecommerce.models.SuperAdmin.Slider.Command;
using FluentValidation;
using Repositories.Slider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.superadmin.Slider.Command.Validations
{
    public class UpdateSliderCommandValidation:AbstractValidator<UpdateSliderCommand>
    {

        public UpdateSliderCommandValidation(ISliderRepository SliderRepository) { 
        

            RuleFor(x=>x.Id)
                .NotEmpty()
                .NotNull()
                .Must(x=> SliderRepository.IsExists(x));


            RuleFor(x => x)
                .Must(x=>SliderRepository.IsUniqueRank(x.Id,x.Rank))
                .OverridePropertyName("Rank");

            RuleFor(x => x)
                .NotEmpty()
                .NotNull()
                .Must(x=>SliderRepository.IsValidLogo(x.Id,x.url))
                .OverridePropertyName("Url");

            

        }

    }
}
