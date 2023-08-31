
using ecommerce.Dto.Base;
using ecommerce.Dto.Results.Admin.Auth.Commands;
using Microsoft.AspNetCore.Identity;

namespace Repositories.Admin.Store
{
    public static class AdminStoreRepository
    {

        public static class Dto
        {

            public static Func<IdentityUser<Guid>,TokenDto, AdminWithToken> AdminWithToken = (IdentityUser<Guid> Account, TokenDto Token) => new AdminWithToken()
            {
                //Email=Account.Email,
                //TokenInfo=Token,
                //IsBlocked=Account.IsBlocked,
                //Id=Account.Admin.Id,
                //UserName=Account.UserName



            };

        }
        
    }
}
