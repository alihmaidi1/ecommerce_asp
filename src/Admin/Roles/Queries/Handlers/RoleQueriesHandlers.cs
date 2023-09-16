using ecommerce.admin.Features.Pages.Commands.Models;
using ecommerce.admin.Features.Roles.Queries.Models;
using ecommerce.Domain.SharedResources;
using ecommerce.models.SuperAdmin.Role.Query;
using ecommerce_shared.OperationResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Repositories.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Features.Roles.Queries.Handlers
{
    public class RoleQueriesHandlers : OperationResult,
        IRequestHandler<GetAllRoleQuery, JsonResult>,
        IRequestHandler<GetRoleQuery, JsonResult>,
        IRequestHandler<GetPermission, JsonResult>


    {

        public IRoleRepository RoleRepository;
        public IStringLocalizer<SharedResource> stringLocalizer;
        public RoleQueriesHandlers(IStringLocalizer<SharedResource> stringLocalizer,
            IRoleRepository RoleRepository) 
        {

            this.stringLocalizer = stringLocalizer;
            this.RoleRepository = RoleRepository;
        }

        public async Task<JsonResult> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            var roles=RoleRepository.GetAllRole();
            return Success(roles,"This Is All Role");
        }

        public async Task<JsonResult> Handle(GetRoleQuery request, CancellationToken cancellationToken)
        {
            var Role = RoleRepository.GetRoleAsync(request.Id);
            return Success(Role,"This is your role");
        }


        async Task<JsonResult> IRequestHandler<GetPermission, JsonResult>.Handle(GetPermission request, CancellationToken cancellationToken)
        {
            List<string> Permissions = RoleRepository.GetAllPermission();
            return Success(Permissions, "this is all permission");

        }
    }
}
