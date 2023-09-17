using ecommerce.models.SuperAdmin.Admin.Query;
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

namespace ecommerce.superadmin.Admin.Query.Handlers
{
    public class AdminQueryHandlers : OperationResult,
        IRequestHandler<GetAllAdminQuery, JsonResult>,
        IRequestHandler<GetAdminQuery, JsonResult>

    {

        public IAdminRepository AdminRepository;

        public AdminQueryHandlers(IAdminRepository AdminRepository) {


            this.AdminRepository= AdminRepository;
        }

        public async Task<JsonResult> Handle(GetAllAdminQuery request, CancellationToken cancellationToken)
        {

            var Admins = AdminRepository.
                GetAllForSuperAdmin().
                Select(x=> AdminStoreQuery.ToBrandResponse.Compile()(x))
                .ToList();


            return Success(Admins, "this is all admin");
        }

        public async Task<JsonResult> Handle(GetAdminQuery request, CancellationToken cancellationToken)
        {


            var Admin = AdminRepository.Get(request.Id);

            return Success(AdminStoreQuery.ToAdminQueryResponse.Compile()(Admin), "this is the admin");

        }
    }
}
