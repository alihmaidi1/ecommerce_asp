using ecommerce.infrutructure;
using ecommerce_shared.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.RefreshToken
{
    public class RefreshTokenRepository : GenericRepository<ecommerce.Domain.Entities.RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(ApplicationDbContext DbContext) : base(DbContext)
        {
        }
    }
}
