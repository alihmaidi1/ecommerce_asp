using ecommerce.models.SuperAdmin.Role.Query;
using FluentValidation;
using Repositories.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Roles.Validations
{
    public class StoreRoleCommandValidation:AbstractValidator<StoreRolecommand>
    {

        public StoreRoleCommandValidation(IRoleRepository RoleRepository) { 
        

            RuleFor(x=>x.Name)
                .NotEmpty()
                .NotNull()
                .Must(x=>RoleRepository.IsUnique(x));


            RuleFor(x => x.Permissions)
                .NotEmpty()
                .Must(permission=>RoleRepository.IsPermissionsExists(permission));
        
        } 

    }
}
