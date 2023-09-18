using ecommerce.models.SuperAdmin.Slider.Query;
using FluentValidation;
using Repositories.Slider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.superadmin.Slider.Query.Validations
{
    public class GetSliderQueryValidation:AbstractValidator<GetSliderQuery>
    {
        public GetSliderQueryValidation(ISliderRepository SliderRepository) { 
        
            RuleFor(x=>x.Id)
                .NotEmpty()
                .NotNull()
                .Must(x=>SliderRepository.IsExists(x));
        
        }

    }
}
