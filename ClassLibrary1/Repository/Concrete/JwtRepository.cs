using ecommerce.Domain.Abstract;
using ecommerce.Domain.Entities;
using ecommerce.Dto.Base;
using ecommerce.infrutructure;
using ecommerce_shared.Jwt;
using ecommerce_shared.Repository.interfaces;
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
        //public ApplicationDbContext Context;
        public JwtRepository(IOptions<JwtSetting> JWTOption) {


            this.JWTOption = JWTOption.Value;
            //this.Context = dbContext;
        }
        public TokenDto GetTokens(Account Account,bool WithRefresh=true)
        {

            var claims = CreateClaim(Account);
            var signingCredentials = GetSigningCredentials(JWTOption);            
            var JwtToken = GetJwtToken(JWTOption,claims, signingCredentials);
            var Token =  new JwtSecurityTokenHandler().WriteToken(JwtToken);
            if (WithRefresh)
            {

                RefreshToken RefreshToken = GenerateRefreshToken();
               // Account.RefreshTokens.Add(RefreshToken);
               // Context.SaveChanges();

                return new TokenDto
                {

                    Token = Token,
                    RefreshToken=RefreshToken.Token,
                    Expired_at=(int)JWTOption.DurationInMinute*60


                };



            }
            return new TokenDto
            {

                Token = Token,
                Expired_at = (int)JWTOption.DurationInMinute * 60


            };
        }
    
    
    
    
    
    
        public List<Claim> CreateClaim(Account Account)
        {

            return new List<Claim>
            {
                new Claim("UserName",Account.UserName),
                new Claim("Email",Account.Email)

            };

        }


        public SigningCredentials GetSigningCredentials(JwtSetting JWTOption)
        {

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTOption.key));
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
            generator.GetBytes( RandomNumber );


            return new RefreshToken()
            {
                Token = Convert.ToBase64String(RandomNumber),
                ExpireAt = DateTime.UtcNow.AddDays(30),                

            };

        }




    }
}
