using AccountEntity=ecommerce.Domain.Entities.Identity.Account;
using RefreshTokenEntity = ecommerce.Domain.Entities.Identity.RefreshToken;

using ecommerce.Dto.Base;
using ecommerce_shared.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Repositories.Jwt
{
    public interface IJwtRepository
    {

        public Task<TokenDto> GetTokensInfo(AccountEntity Account);

        public string GetToken(AccountEntity Account);





    }
}
