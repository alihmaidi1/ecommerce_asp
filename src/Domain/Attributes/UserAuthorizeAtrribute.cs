using ecommerce.Domain.Attribute;
using ecommerce_shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.Attributes
{
    public class UserAuthorizeAtrribute: CheckTokenInRedisAttribute
    {

        public UserAuthorizeAtrribute() {

            AuthenticationSchemes = JwtSchema.User.ToString();
        }
    }
}
