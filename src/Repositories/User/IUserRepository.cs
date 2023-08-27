using ecommerce.Domain.Abstract;
using Repositories.Base;

namespace Repositories.User
{
    public interface IUserRepository: IgenericRepository<ecommerce.Domain.Entities.User>
    {

        public  Task<Account> GetUserByUserNameOrEmail(string UserNameOrEmail);

    }
}
