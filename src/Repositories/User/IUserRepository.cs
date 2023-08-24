using ecommerce.Domain.Abstract;
using ecommerce.Domain.Entities;
using ecommerce_shared.Repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.User
{
    public interface IUserRepository: IgenericRepository<ecommerce.Domain.Entities.User>
    {

        public  Task<Account> GetUserByUserNameOrEmail(string UserNameOrEmail);

    }
}
