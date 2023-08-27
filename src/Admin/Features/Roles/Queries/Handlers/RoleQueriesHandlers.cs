using ecommerce.admin.Features.Pages.Commands.Models;
using ecommerce.admin.Features.Roles.Queries.Models;
using ecommerce.Domain.SharedResources;
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
        IRequestHandler<GetAllRoleQuery, JsonResult>
    {

        public IRoleRepository RoleRepository;
        public RoleQueriesHandlers(IStringLocalizer<SharedResource> stringLocalizer,
            IRoleRepository RoleRepository) : base(stringLocalizer)
        {

            this.RoleRepository = RoleRepository;
        }

        public async Task<JsonResult> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            var roles=RoleRepository.GetAllRole();
            return Success(roles,"This Is All Role");
        }
    }
}
