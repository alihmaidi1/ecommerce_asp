using ecommerce.infrutructure;
using Repositories.Base.Concrete;

namespace Repositories.RefreshToken
{
    public class RefreshTokenRepository : GenericRepository<ecommerce.Domain.Entities.Identity.RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(ApplicationDbContext DbContext) : base(DbContext)
        {
        }
    }
}
