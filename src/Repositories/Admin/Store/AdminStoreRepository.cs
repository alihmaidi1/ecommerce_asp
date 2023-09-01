<<<<<<< HEAD
﻿using AccountEntity=ecommerce.Domain.Entities.Identity.Account;
=======
﻿
>>>>>>> 90bac4133691690d5adc946ac38d3faf668d9f45
using ecommerce.Dto.Base;
using ecommerce.Dto.Results.Admin.Auth.Commands;
using Microsoft.AspNetCore.Identity;

namespace Repositories.Admin.Store
{
    public static class AdminStoreRepository
    {

        public static class Dto
        {

<<<<<<< HEAD
            public static Func<AccountEntity, TokenDto, AdminWithToken> AdminWithToken = (AccountEntity Account, TokenDto Token) => new AdminWithToken()
=======
            public static Func<IdentityUser<Guid>,TokenDto, AdminWithToken> AdminWithToken = (IdentityUser<Guid> Account, TokenDto Token) => new AdminWithToken()
>>>>>>> 90bac4133691690d5adc946ac38d3faf668d9f45
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
