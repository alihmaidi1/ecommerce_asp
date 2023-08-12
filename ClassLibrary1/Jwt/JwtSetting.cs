using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Jwt
{
    public  class JwtSetting
    {

        public string key {get; set;}
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string DurationInMinute { get; set; }

    }
}
