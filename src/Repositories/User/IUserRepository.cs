using ecommerce.Domain.Entities.Identity;
using Repositories.Base;

namespace Repositories.User
{
    public interface IUserRepository: IgenericRepository<ecommerce.Domain.Entities.Identity.User>
    {

        public  Task<ecommerce.Domain.Entities.Identity.Account> GetUserByUserNameOrEmail(string UserNameOrEmail);

    }
}
