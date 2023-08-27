using ecommerce.Domain.Abstract;
using ecommerce.Dto.Base;
using ecommerce.infrutructure;
using ecommerce.infrutructure.Services.Interfaces;
using ecommerce_shared.Jwt;
using ecommerce_shared.Redis;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Repositories.Jwt
{
    public class JwtRepository : IJwtRepository
    {

        public readonly JwtSetting JWTOption;
        public readonly ApplicationDbContext Context;
        public readonly ICacheRepository CacheRepository;
        public readonly UserManager<Account> UserManager;
        public JwtRepository(IOptions<JwtSetting> JWTOption, ApplicationDbContext DbContext, UserManager<Account> UserManager, ICacheRepository cacheRepository)
        {

            this.JWTOption = JWTOption.Value;
            Context = DbContext;
            this.UserManager = UserManager;
            CacheRepository = cacheRepository;
            CacheRepository = cacheRepository;
        }
        public async Task<TokenDto> GetTokens(Account Account)
        {
            var claims = CreateClaim(Account);

            var signingCredentials = GetSigningCredentials(JWTOption);
            var JwtToken = GetJwtToken(JWTOption, claims, signingCredentials);
            var Token = new JwtSecurityTokenHandler().WriteToken(JwtToken);

            var ExpiredAt = DateTimeOffset.Now.AddMinutes(JWTOption.DurationInMinute);
            CacheRepository.SetData("Token:" + Token, Token, ExpiredAt);
            ecommerce.Domain.Entities.RefreshToken RefreshToken = GenerateRefreshToken();


            Account.RefreshTokens.Add(RefreshToken);
            Context.SaveChanges();
            return TokenDto.ToTokenDto(Token, (int)(JWTOption.DurationInMinute * 60), RefreshToken);


        }






        public List<Claim> CreateClaim(Account Account)
        {

            var Claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,Account.UserName),
                new Claim(ClaimTypes.Email,Account.Email),
                new Claim(ClaimTypes.NameIdentifier,Account.Id.ToString())

            };


            return Claims;



        }


        public SigningCredentials GetSigningCredentials(JwtSetting JWTOption)
        {

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTOption.Key));
            return new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);



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


        public ecommerce.Domain.Entities.RefreshToken GenerateRefreshToken()
        {

            var RandomNumber = new byte[32];
            var generator = new RNGCryptoServiceProvider();
            generator.GetBytes(RandomNumber);


            return new ecommerce.Domain.Entities.RefreshToken()
            {
                Token = Convert.ToBase64String(RandomNumber),
                ExpireAt = DateTime.UtcNow.AddDays(30),

            };

        }

    }
}
