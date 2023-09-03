using ecommerce.Dto.Base;
using ecommerce.Dto.Results.User.Auth.Command;
using Repositories.City.CityStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.User.Store
{
    public class UserStoreService
    {
        public static class Filter
        {



        }


        public static class Query {


            public static Func<ecommerce.Domain.Entities.Identity.User, TokenDto, UserWithToken> CreateUserResponse=> (User, TokenInfo) => new UserWithToken()
            {

                Id = User.Id,
                Name = User.Name,
                UserName = User.UserName,
                City = User.City!=null?CityStoreService.Query.ToCityName(User.City):null,
                Email = User.Email,
                IsBlocked = User.IsBlocked,
                Point = User.Point,
                TokenInfo = TokenInfo

            };
        
            
        }



    }
}
