using ecommerce.Domain.Abstract;
using ecommerce.Domain.Entities;
using ecommerce.Dto.Base;
using ecommerce_shared.Jwt;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Repository.interfaces
{
    public interface IJwtRepository
    {

        public  Task<TokenDto> GetTokens(Account Account);


        public List<Claim> CreateClaim(Account Account);


        public SigningCredentials GetSigningCredentials(JwtSetting JWTOption);


        public JwtSecurityToken GetJwtToken(JwtSetting JWTOption, List<Claim> claims, SigningCredentials SigningCredentials);
    

        public RefreshToken GenerateRefreshToken();  
    
    }
}
