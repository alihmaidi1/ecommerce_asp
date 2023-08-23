using ecommerce.Domain.Abstract;
using ecommerce.Domain.Entities;
using ecommerce.Dto.Base;
using ecommerce.infrutructure;
using ecommerce_shared.Jwt;
using ecommerce_shared.Repository.interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Repository.Concrete
{
    public class JwtRepository : IJwtRepository
    {

        public readonly JwtSetting JWTOption;
        public readonly ApplicationDbContext Context;

        public readonly UserManager<Account> UserManager;
        public JwtRepository(IOptions<JwtSetting> JWTOption, ApplicationDbContext DbContext, UserManager<Account> UserManager)
        {

            this.JWTOption = JWTOption.Value;
            this.Context = DbContext;
            this.UserManager = UserManager;
        }
        public async Task<TokenDto> GetTokens(Account Account)
        {
            var Roles=await UserManager.GetRolesAsync(Account);
            var claims = CreateClaim(Account,Roles.ToList());

            var signingCredentials = GetSigningCredentials(JWTOption);            
            var JwtToken = GetJwtToken(JWTOption,claims, signingCredentials);
            var Token =  new JwtSecurityTokenHandler().WriteToken(JwtToken);
            RefreshToken RefreshToken = GenerateRefreshToken();

            
            Account.RefreshTokens.Add(RefreshToken);
            Context.SaveChanges();
            return TokenDto.ToTokenDto(Token,(int)(JWTOption.DurationInMinute * 60),RefreshToken);
                
                                  
        }
    
    
    
    
    
    
        public List<Claim> CreateClaim(Account Account,List<string> Roles)
        {

            var Claims= new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,Account.UserName),
                new Claim(ClaimTypes.Email,Account.Email)
                

            };

            Roles.ForEach(r => Claims.Add(new Claim(ClaimTypes.Role, r.ToString())));

            return Claims;

            

        }


        public SigningCredentials GetSigningCredentials(JwtSetting JWTOption)
        {

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTOption.Key));
            return  new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);



        }


        public JwtSecurityToken GetJwtToken(JwtSetting JWTOption, List<Claim> claims, SigningCredentials SigningCredentials)
        {

            return new JwtSecurityToken(
               issuer: JWTOption.Issuer,
               audience: JWTOption.Audience,
               claims: claims,
               expires: DateTime.Now.AddMinutes(JWTOption.DurationInMinute),
               signingCredentials: SigningCredentials
               );

        }


        public RefreshToken GenerateRefreshToken()
        {

            var RandomNumber = new byte[32];
            var generator = new RNGCryptoServiceProvider();
            generator.GetBytes(RandomNumber);


            return new RefreshToken()
            {
                Token = Convert.ToBase64String(RandomNumber),
                ExpireAt = DateTime.UtcNow.AddDays(30),                

            };

        }

    }
}
