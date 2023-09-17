using ecommerce.models.SuperAdmin.Admin.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.superadmin.Admin.Command.Validations
{
    public class UnBlockAdminCommandValidation:AbstractValidator<UnBlockAdminCommand>
    {

        public UnBlockAdminCommandValidation() { 
        
            RuleFor(x=>x.Id)
                .NotEmpty()
                .NotNull();
        
        }  

    }
}
