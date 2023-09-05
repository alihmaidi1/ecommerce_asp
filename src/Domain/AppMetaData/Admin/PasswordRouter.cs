using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.AppMetaData.Admin
{
    public static class PasswordRouter
    {
        private const string prefix = Router.Rule + "password";
        public const string ResetPassword = prefix + "/resetPassword";
        public const string CheckCode = prefix + "/checkCode";


    }
}
