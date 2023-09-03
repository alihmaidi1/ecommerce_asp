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
        public const string AuthWithGoogle = prefix + "/AuthWithGoogle";


        public const string Confirm = prefix + "/ConfirmAccount";


        public const string Login = prefix + "/Login";
        public const string Logout = prefix + "/Logout";

    }
}
