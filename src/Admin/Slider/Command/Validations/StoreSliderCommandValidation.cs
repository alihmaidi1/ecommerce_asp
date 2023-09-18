using ecommerce.models.SuperAdmin.Slider.Command;
using ecommerce_shared.Rule;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.superadmin.Slider.Command.Validations
{
    public class StoreSliderCommandValidation:AbstractValidator<StoreSliderCommand>
    {

        public StoreSliderCommandValidation(IWebHostEnvironment webhost) {

            RuleFor(x => x.Url)
                .NotEmpty()
                .NotNull()
                .Must(x=>FileRule.isFileExists(x, webhost.WebRootPath));

            RuleFor(x => x.Rank)
                .NotEmpty()
                .NotNull()
                .Must(x=>true);
        
        }


    }
}
