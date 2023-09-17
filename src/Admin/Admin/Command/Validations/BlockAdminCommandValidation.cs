using Amazon.Runtime.Internal;
using ecommerce.models.SuperAdmin.Admin.Commands;
using FluentValidation;
using Repositories.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.superadmin.Admin.Command.Validations
{
    public class BlockAdminCommandValidation:AbstractValidator<BlockAdminCommand>
    {

        public BlockAdminCommandValidation(IAdminRepository AdminRepository) {


            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .Must(x=> AdminRepository.isExists(x));
        
        }


    }
}
