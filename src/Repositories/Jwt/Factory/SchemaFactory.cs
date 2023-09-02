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
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Repositories.Jwt.Factory
{
    public class SchemaFactory : ISchemaFactory
    {

        public ApplicationDbContext DbContext { get; set; }

        public UserManager<AccountEntity> UserManager;
        
        public ICacheRepository CacheRepository;

        public IConfiguration configration { get; set; }
        public SchemaFactory(IConfiguration configration, ApplicationDbContext DbContext, UserManager<AccountEntity> UserManager, ICacheRepository CacheRepository) {

            this.configration = configration;
            this.DbContext = DbContext;
            this.UserManager = UserManager;
            this.CacheRepository = CacheRepository;
        
        }

        public IJwtRepository CreateJwt(JwtSchema Schema)
        {
            var Setting=configration.GetSection(Schema.ToString()).Get<JwtSetting>();
            return new JwtRepository(Setting, DbContext, UserManager, CacheRepository);
        }
    }
}
