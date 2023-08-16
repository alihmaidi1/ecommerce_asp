using ecommerce.user.Features.Auth.Commands.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.user.Features.Auth.Commands.Validations
{
    public class AddUserValidation:AbstractValidator<AddUserCommand>
    {

        public AddUserValidation() {

            ApplyUserNameValidation();
            ApplyPasswordValidation();
            ApplyEmailValidation();
            ApplyNameValidation();
            ApplyCityValidation();
            ApplyDateOfBirthValidation();

        }
        
        public void ApplyUserNameValidation()
        {


        }

        public void ApplyPasswordValidation()
        {


        }



        public void ApplyEmailValidation()
        {


        }

        public void ApplyNameValidation()
        {


        }

        public void ApplyDateOfBirthValidation()
        {


        }

        public void ApplyCityValidation()
        {


        }
        

    }
}
