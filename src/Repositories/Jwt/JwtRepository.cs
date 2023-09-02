using AccountEntity=ecommerce.Domain.Entities.Identity.Account;
using ecommerce.Dto.Base;
using ecommerce.infrutructure;
using ecommerce_shared.Jwt;
using ecommerce_shared.Redis;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Repositories.Jwt
{
    public class JwtRepository : IJwtRepository
    {

        public readonly IJwtSetting JWTOption;
        public readonly ApplicationDbContext Context; 
        public readonly ICacheRepository CacheRepository;
        public readonly UserManager<AccountEntity> UserManager;
        public JwtRepository(IJwtSetting Setting, ApplicationDbContext DbContext, UserManager<AccountEntity> UserManager, ICacheRepository cacheRepository)
        {

            this.JWTOption = Setting;
            Context = DbContext;
            this.UserManager = UserManager;
            CacheRepository = cacheRepository;
        }
        public async Task<TokenDto> GetTokensInfo(AccountEntity Account)
        {
            string Token = GetToken(Account);
            ecommerce.Domain.Entities.Identity.RefreshToken RefreshToken = GenerateRefreshToken();
            Account.RefreshTokens.Add(RefreshToken);
            Context.SaveChanges();
            return TokenDto.ToTokenDto(Token, (int)(JWTOption.DurationInMinute * 60), RefreshToken);

        }

        public string GetToken(AccountEntity Account)
        {
            var claims = CreateClaim(Account);
            var signingCredentials = GetSigningCredentials(JWTOption);
            var JwtToken = GetJwtToken(JWTOption, claims, signingCredentials);
            var Token = new JwtSecurityTokenHandler().WriteToken(JwtToken);
            var ExpiredAt = DateTimeOffset.Now.AddMinutes(JWTOption.DurationInMinute);
            CacheRepository.SetData("Token:" + Token, Token, ExpiredAt);
            return Token;

        }






        private List<Claim> CreateClaim(AccountEntity Account)
        {

            var Claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,Account.UserName),
                new Claim(ClaimTypes.Email,Account.Email),
                new Claim(ClaimTypes.NameIdentifier,Account.Id.ToString())

            };


            return Claims;



        }


        private SigningCredentials GetSigningCredentials(IJwtSetting JWTOption)
        {

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTOption.Key));
            return new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);



        }


        private JwtSecurityToken GetJwtToken(IJwtSetting JWTOption, List<Claim> claims, SigningCredentials SigningCredentials)
        {

            return new JwtSecurityToken(
               issuer: JWTOption.Issuer,
               audience: JWTOption.Audience,
               claims: claims,
               expires: DateTime.Now.AddMinutes(JWTOption.DurationInMinute),
               signingCredentials: SigningCredentials
               );

        }


        private ecommerce.Domain.Entities.Identity.RefreshToken GenerateRefreshToken()
        {

            var RandomNumber = new byte[32];
            var generator = new RNGCryptoServiceProvider();
            generator.GetBytes(RandomNumber);


            return new ecommerce.Domain.Entities.Identity.RefreshToken()
            {
                Token = Convert.ToBase64String(RandomNumber),
                ExpireAt = DateTime.UtcNow.AddDays(30),

            };

        }

    }
}
