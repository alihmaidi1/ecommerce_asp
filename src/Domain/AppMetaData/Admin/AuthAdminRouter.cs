using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.AppMetaData.Admin
{
    public static class AuthAdminRouter
    {
        
        private const string prefix = Router.Rule + Router.Admin+ "/auth";
        public const string Login = prefix + "/login";
        public const string Logout = prefix + "/logout";


    }
}
