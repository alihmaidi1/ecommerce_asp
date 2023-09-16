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
    public class GetRoleQueryValidation:AbstractValidator<GetRoleQuery>
    {

        public GetRoleQueryValidation(IRoleRepository RoleRepository) { 
        
            RuleFor(x=>x.Id)
                .NotEmpty()
                .NotNull()
                .Must(x=> RoleRepository.IsExists(x));
        
        }


    }
}
