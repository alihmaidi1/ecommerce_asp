using ecommerce.Domain.Attribute;
using ecommerce.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.Attributes
{
    public class AppAuthorizeAttribute: CheckTokenInRedisAttribute
    {
            

        public AppAuthorizeAttribute(params RoleEnum[] roles) { 
        
            if(roles.Length != 0)
            {

                Roles = string.Join(",", roles.Select(x => x.ToString()));

            }


        }


    }
}
