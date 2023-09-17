using ecommerce.models.SuperAdmin.Admin.Commands;
using FluentValidation;
using Repositories.Admin;
using Repositories.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.superadmin.Admin.Command.Validations
{
    public class UpdateAdminCommandValidation:AbstractValidator<UpdateAdminCommand>
    {

        public UpdateAdminCommandValidation(IAdminRepository AdminRepository,IRoleRepository RoleRepository) { 
        
            RuleFor(x=>x)
                .Must(x=>AdminRepository.IsUniqueEmail(x.Email,x.Id))
                .OverridePropertyName("Email");
            
            
            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x)
                .Must(x=>AdminRepository.IsUniqueUserName(x.UserName,x.Id));

            RuleFor(x => x.RoleId)
                .NotNull()
                .NotEmpty()
                .Must(x=> RoleRepository.IsIdExists(x));

        
        }

    }
}
