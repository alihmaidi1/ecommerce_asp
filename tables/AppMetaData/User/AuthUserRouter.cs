using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.AppMetaData.User
{
    public static class AuthUserRouter
    {


        private const string prefix = Router.Rule+Router.User+"Auth" ;
        public const string Create = prefix + "/Store";
    }
}
