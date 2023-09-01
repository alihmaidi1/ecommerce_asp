using AccountEntity=ecommerce.Domain.Entities.Identity.Account;
using ecommerce.infrutructure;
using ecommerce_shared.Enums;
using ecommerce_shared.Jwt;
using ecommerce_shared.Redis;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Repositories.Jwt.Factory
{
    public class SchemaFactory : ISchemaFactory
    {

        public ApplicationDbContext DbContext { get; set; }

        public UserManager<AccountEntity> UserManager;
        public JwtSetting jwtSetting { get; set; }
        public ResetSetting ResetSetting { get; set; }

        public ICacheRepository CacheRepository;

        public SchemaFactory(IOptions<JwtSetting> JwtSetting,IOptions<ResetSetting> ResetSetting,ApplicationDbContext DbContext, UserManager<AccountEntity> UserManager, ICacheRepository CacheRepository) {

            this.jwtSetting = JwtSetting.Value;
            this.ResetSetting = ResetSetting.Value;
            this.DbContext = DbContext;
            this.UserManager = UserManager;
            this.CacheRepository = CacheRepository;
        
        }

        public IJwtRepository CreateJwt(JwtSchema Schema)
        {
            IJwtSetting Setting=(nameof(Schema) != nameof(JwtSchema.Main)) ?jwtSetting:ResetSetting;            
            return new JwtRepository(Setting, DbContext, UserManager, CacheRepository);
        }
    }
}
