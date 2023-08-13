using ecommerce.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Repository.interfaces
{
    public interface IJwtRepository
    {

        public string GetToken(Account Account);
    }
}
