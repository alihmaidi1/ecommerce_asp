using ecommerce.models.SuperAdmin.Role.Commands;
using ecommerce.models.SuperAdmin.Role.Query;
using ecommerce_shared.OperationResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Repositories.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Roles.Commands
{
    public class RoleCommandHandlers : OperationResult,
        IRequestHandler<StoreRolecommand, JsonResult>,
        IRequestHandler<UpdateRoleCommand, JsonResult>,
        IRequestHandler<DeleteRoleCommand, JsonResult>


    {

        public readonly IRoleRepository RoleRepository;

        public RoleCommandHandlers(IRoleRepository RoleRepository) { 
        

            this.RoleRepository=RoleRepository;
        }

        public async Task<JsonResult> Handle(StoreRolecommand request, CancellationToken cancellationToken)
        {


            var Role=await RoleRepository.StoreRole(request);

            return Success(Role, "the role was created successfully");




        }

        public async Task<JsonResult> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {

            var Role = await RoleRepository.UpdateRole(Guid.Parse(request.Id), request.Name, request.Permissions);

            return Success(Role,"the role was updated successfully");
        }

        public async Task<JsonResult> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {

            var Role = RoleRepository.Delete(request.Id);

            return Success(Role, "the role was deleted successfully");

        }
    }
}
