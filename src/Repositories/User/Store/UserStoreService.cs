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


<<<<<<< HEAD
            public static Func<ecommerce.Domain.Entities.Identity.User, TokenDto, UserWithToken> CreateUserResponse=> (User, TokenInfo) => new UserWithToken()
            {
=======
            //public static Func<ecommerce.Domain.Entities.User, TokenDto, UserWithToken> CreateUserResponse=> (User, TokenInfo) => new UserWithToken()
            //{
>>>>>>> 90bac4133691690d5adc946ac38d3faf668d9f45

            //    Id = User.Id,
            //    Name = User.Name,
            //    UserName = User.Account.UserName,
            //    City = CityStoreService.Query.ToCityName(User.City),
            //    Email = User.Account.Email,
            //    IsBlocked = User.IsBlocked,
            //    Point = User.Point,
            //    TokenInfo = TokenInfo

            //};
        
            
        }



    }
}
