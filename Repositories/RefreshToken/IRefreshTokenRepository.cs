using ecommerce.Domain.Entities;
using ecommerce_shared.Repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.RefreshToken
{
    public interface IRefreshTokenRepository: IgenericRepository<ecommerce.Domain.Entities.RefreshToken>
    {


    }
}
