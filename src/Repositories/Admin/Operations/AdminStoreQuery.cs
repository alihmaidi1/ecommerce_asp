using AdminEntity=ecommerce.Domain.Entities.Identity.Admin;
using ecommerce.Dto.Results.Admin.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ecommerce.Dto.Results.Admin.Admin;

namespace Repositories.Admin.Store
{
    public static class AdminStoreQuery
    {

        public static Expression<Func<AdminEntity, GetAllAdminQuery>> ToBrandResponse = b => new GetAllAdminQuery()
        {
            Id = b.Id,
            UserName=b.UserName,
            Email=b.Email,            
            isBlocked=b.IsBlocked,
            EmailConfirmed=b.EmailConfirmed
            


        };


    }
}
