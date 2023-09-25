//using UserEntity=ecommerce.Domain.Entities.Identity.User;
//using ecommerce_shared.Enums;
//using ecommerce_shared.Services.Authentication.ResponseAuth;
//using Repositories.Base;

//namespace Repositories.User
//{
//    public interface IUserRepository: IgenericRepository<ecommerce.Domain.Entities.Identity.User>
//    {

        
//        public Task<bool> CheckEmailExists(string Email);
//        public bool IsEmailConfirmed(string Email);




//        public bool IsUserNameExists(string UserName);
//        public bool IsLocalUserNameExists(string UserName);

//        public Task<bool> ChangePassword(Guid Id,string Password);

//        public Task<ecommerce.Domain.Entities.Identity.User> GetUserByProviderId(string Id,ProviderAuthentication provider);


//        public Task<ecommerce.Domain.Entities.Identity.User> CreateExternalUser(Response ApiResponse,ProviderAuthentication provider);
//    }
//}
