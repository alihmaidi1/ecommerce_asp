using AccountEntity=ecommerce.Domain.Entities.Identity.Account;
using ecommerce.Dto.Base;
using ecommerce.Dto.Results.Admin.Auth.Commands;

namespace Repositories.Admin.Store
{
    public static class AdminStoreRepository
    {

        public static class Dto
        {

            public static Func<AccountEntity, TokenDto, AdminWithToken> AdminWithToken = (AccountEntity Account, TokenDto Token) => new AdminWithToken()
            {
                Email=Account.Email,
                TokenInfo=Token,
                IsBlocked=Account.IsBlocked,
                Id=Account.Id,
                UserName=Account.UserName



            };

        }
        
    }
}
