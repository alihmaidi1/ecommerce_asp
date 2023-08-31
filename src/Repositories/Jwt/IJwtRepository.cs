
using ecommerce.Dto.Base;
using ecommerce_shared.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Repositories.Jwt
{
    public interface IJwtRepository
    {

        public Task<TokenDto> GetTokens(IdentityUser<Guid> Account);


        public List<Claim> CreateClaim(IdentityUser<Guid> Account);


        public SigningCredentials GetSigningCredentials(JwtSetting JWTOption);


        public JwtSecurityToken GetJwtToken(JwtSetting JWTOption, List<Claim> claims, SigningCredentials SigningCredentials);


        public ecommerce.Domain.Entities.RefreshToken GenerateRefreshToken();

    }
}
