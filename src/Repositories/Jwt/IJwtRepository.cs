<<<<<<< HEAD
﻿using AccountEntity=ecommerce.Domain.Entities.Identity.Account;
using RefreshTokenEntity = ecommerce.Domain.Entities.Identity.RefreshToken;

=======
﻿
>>>>>>> 90bac4133691690d5adc946ac38d3faf668d9f45
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

<<<<<<< HEAD
        public Task<TokenDto> GetTokens(AccountEntity Account);


        public List<Claim> CreateClaim(AccountEntity Account);
=======
        public Task<TokenDto> GetTokens(IdentityUser<Guid> Account);


        public List<Claim> CreateClaim(IdentityUser<Guid> Account);
>>>>>>> 90bac4133691690d5adc946ac38d3faf668d9f45


        public SigningCredentials GetSigningCredentials(JwtSetting JWTOption);


        public JwtSecurityToken GetJwtToken(JwtSetting JWTOption, List<Claim> claims, SigningCredentials SigningCredentials);


        public RefreshTokenEntity GenerateRefreshToken();

    }
}
