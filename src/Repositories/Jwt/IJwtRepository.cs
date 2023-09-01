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

        public Task<TokenDto> GetTokens(AccountEntity Account);


        public List<Claim> CreateClaim(AccountEntity Account);


        public SigningCredentials GetSigningCredentials(JwtSetting JWTOption);


        public JwtSecurityToken GetJwtToken(JwtSetting JWTOption, List<Claim> claims, SigningCredentials SigningCredentials);


        public RefreshTokenEntity GenerateRefreshToken();

    }
}
