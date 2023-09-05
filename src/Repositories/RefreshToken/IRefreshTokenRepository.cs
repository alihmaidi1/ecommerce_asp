using Repositories.Base;

namespace Repositories.RefreshToken
{
    public interface IRefreshTokenRepository: IgenericRepository<ecommerce.Domain.Entities.Identity.RefreshToken>
    {

        public bool IsValid(string Token);

    }
}
