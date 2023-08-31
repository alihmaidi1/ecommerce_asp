
using Microsoft.AspNetCore.Identity;
using Repositories.Base;

namespace Repositories.User
{
    public interface IUserRepository: IgenericRepository<ecommerce.Domain.Entities.User>
    {

        public  Task<IdentityUser<Guid>> GetUserByUserNameOrEmail(string UserNameOrEmail);

    }
}
