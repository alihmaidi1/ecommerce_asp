using ecommerce.models.SuperAdmin.Admin.Commands;
using ecommerce_shared.OperationResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Repositories.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.superadmin.Admin.Command.Handlers
{
    public class AdminCommandHandlers : OperationResult,
        IRequestHandler<StoreAdminCommand, JsonResult>


    {

        public IAdminRepository AdminRepository;
        public AdminCommandHandlers(IAdminRepository AdminRepository) { 
        

            this.AdminRepository=AdminRepository;
        
        }


        public async Task<JsonResult> Handle(StoreAdminCommand request, CancellationToken cancellationToken)
        {

            var Admin =  await AdminRepository.Store(request.Email, request.UserName, request.Password,request.RoleId);

            return Success(Admin, "the admin was added successfully");
        }
    }
}
