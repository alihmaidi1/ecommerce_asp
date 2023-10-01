using ecommerce.models.SuperAdmin.Admin.Commands;
using ecommerce_shared.OperationResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Repositories.Admin;
using Repositories.Admin.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.superadmin.Admin.Command.Handlers
{
    public class AdminCommandHandlers : OperationResult,
        IRequestHandler<StoreAdminCommand, JsonResult>,
        IRequestHandler<BlockAdminCommand, JsonResult>,
        IRequestHandler<UnBlockAdminCommand, JsonResult>,
        IRequestHandler<UpdateAdminCommand, JsonResult>





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

        public async Task<JsonResult> Handle(BlockAdminCommand request, CancellationToken cancellationToken)
        {

            AdminRepository.BlockAdmin(request.Id);
            return Success(true,"the admin was blocked successfully");
        }

        public async Task<JsonResult> Handle(UnBlockAdminCommand request, CancellationToken cancellationToken)
        {

            AdminRepository.UnBlockAdmin(request.Id);
            return Success(true,"the admin was unblocked successfully");

        
        }

        public async Task<JsonResult> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
        {

            var Admin = await AdminRepository.Update(request.Id, request.Email, request.UserName, request.Password, request.RoleId);
            return Success(AdminStoreQuery.ToAdminUpdatedResponse.Compile()(Admin),"the admin was updated successfully");
            
        }
    }
}
