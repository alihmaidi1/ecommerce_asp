using ecommerce.Domain.Abstract;
using ecommerce_shared.Jwt;
using ecommerce_shared.Repository.interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Repository.Concrete
{
    public class JwtRepository : IJwtRepository
    {

        public readonly JwtSetting JWTOption;
        public JwtRepository(IOptions<JwtSetting> JWTOption) {


            this.JWTOption = JWTOption.Value;
        }
        public string GetToken(Account Account)
        {

            var claim = new List<Claim>
            {
                new Claim("UserName",Account.UserName),
                new Claim("Email",Account.Email)

            };
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTOption.key));
            var signingCredentials=new SigningCredentials(symmetricSecurityKey,SecurityAlgorithms.HmacSha256);
            
            var JwtToken = new JwtSecurityToken(

               issuer:JWTOption.Issuer,
               audience:JWTOption.Audience,
               claims: claim,
               expires:DateTime.Now.AddMinutes(JWTOption.DurationInMinute),
               signingCredentials:signingCredentials
               
               );
            var Token =  new JwtSecurityTokenHandler().WriteToken(JwtToken);
            return Token;
        }
    }
}
