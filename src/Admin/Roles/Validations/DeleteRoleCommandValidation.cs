using ecommerce.models.SuperAdmin.Role.Commands;
using FluentValidation;
using Repositories.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Roles.Validations
{
    public class DeleteRoleCommandValidation:AbstractValidator<DeleteRoleCommand>
    {

        public DeleteRoleCommandValidation(IRoleRepository RoleRepository) { 
        

            RuleFor(x=>x.Id)
                .NotEmpty()
                .NotNull()
                .Must(id=>RoleRepository.IsIdExists(id));
        
        }

    }
}
