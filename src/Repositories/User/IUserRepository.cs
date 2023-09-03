using ecommerce.Domain.Entities.Identity;
using ecommerce_shared.Enums;
using ecommerce_shared.Services.Authentication;
using Repositories.Base;

namespace Repositories.User
{
    public interface IUserRepository: IgenericRepository<ecommerce.Domain.Entities.Identity.User>
    {

        
        public Task<bool> CheckEmailExists(string Email);


        public Task<ecommerce.Domain.Entities.Identity.User> GetUserByProviderId(string Id,ProviderAuthentication provider);


        public Task<ecommerce.Domain.Entities.Identity.User> CreateExternalUser(Response ApiResponse,ProviderAuthentication provider);
    }
}
