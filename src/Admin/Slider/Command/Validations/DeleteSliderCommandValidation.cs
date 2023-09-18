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
    public class DeleteSliderCommandValidation:AbstractValidator<DeleteSliderCommand>
    {

        public DeleteSliderCommandValidation(ISliderRepository SliderRepository) {

            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .Must(x=> SliderRepository.IsExists(x));
        
        }

    }
}
