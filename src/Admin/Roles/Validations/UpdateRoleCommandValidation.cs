using Amazon.Runtime.Internal;
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
    public class UpdateRoleCommandValidation:AbstractValidator<UpdateRoleCommand>
    {


        public UpdateRoleCommandValidation(IRoleRepository RoleRepository)
        {

            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .Must(x=> RoleRepository.IsExists(x));

            RuleFor(x => x.Permissions)
                .NotEmpty()
                .NotNull()
                .Must(x=>RoleRepository.IsPermissionsExists(x));

            RuleFor(x => x)                
                .Must(x => RoleRepository.IsUniqueWithId(x.Id, x.Name))
                .OverridePropertyName("Name");
            

        }

    }
}
