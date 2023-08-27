using ecommerce.Domain.Abstract;
using ecommerce.Dto.Base;
using ecommerce.Dto.Results.Admin.Auth.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Admin.Store
{
    public static class AdminStoreRepository
    {

        public static class Dto
        {

            public static Func<Account,TokenDto, AdminWithToken> AdminWithToken = (Account Account, TokenDto Token) => new AdminWithToken()
            {
                Email=Account.Email,
                TokenInfo=Token,
                IsBlocked=Account.Admin.IsBlocked,
                Id=Account.Admin.Id,
                UserName=Account.UserName



            };

        }
        
    }
}
