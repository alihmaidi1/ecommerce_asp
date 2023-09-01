using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Jwt
{
    public  class JwtSetting:IJwtSetting
    {

        public string Key {get; set;}
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double DurationInMinute { get; set; }

    }
}
