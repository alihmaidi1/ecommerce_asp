using AdminEntity=ecommerce.Domain.Entities.Identity.Admin;
using ecommerce.Dto.Results.Admin.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ecommerce.Dto.Results.Admin.Admin;
using ecommerce.models.SuperAdmin.Admin.Query;

namespace Repositories.Admin.Store
{
    public static class AdminStoreQuery
    {

        public static Expression<Func<AdminEntity, ecommerce.Dto.Results.Admin.Admin.GetAllAdminQuery>> ToBrandResponse = b => new ecommerce.Dto.Results.Admin.Admin.GetAllAdminQuery()
        {
            Id = b.Id,
            UserName=b.UserName,
            Email=b.Email,            
            isBlocked=b.IsBlocked,
            EmailConfirmed=b.EmailConfirmed
            


        };


        public static Expression<Func<AdminEntity, GetAdminQueryResponse>> ToAdminQueryResponse = b => new GetAdminQueryResponse()
        {
            Id = b.Id,
            
            UserName = b.UserName,
            Email = b.Email,
            IsBlocked = b.IsBlocked,
            ConfirmedEmail = b.EmailConfirmed



        };


        public static Expression<Func<AdminEntity, UpdateAdminresponse>> ToAdminUpdatedResponse = b => new UpdateAdminresponse()
        {
            Id = b.Id,

            UserName = b.UserName,
            Email = b.Email,
            IsBlocked = b.IsBlocked



        };

    }
}
