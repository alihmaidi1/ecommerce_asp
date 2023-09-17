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
    public class StoreAdminCommandValidation:AbstractValidator<StoreAdminCommand>
    {

        public StoreAdminCommandValidation(IAdminRepository AdminRepository,IRoleRepository RoleRepository)
        {

            RuleFor(x=>x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .Must(x=> !AdminRepository.CheckEmailExists(x));

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty();
            

            RuleFor(x => x.UserName)
                .NotEmpty()
                .NotNull()
                .Must(x=>AdminRepository.IsUniqueUserName(x));


            RuleFor(x => x.RoleId)
                .NotNull()
                .NotEmpty()
                .Must(x=> RoleRepository.IsIdExists(x));
        
        
        
        
        }




    }
}
