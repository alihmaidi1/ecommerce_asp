using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.AppMetaData.Admin
{
    public static class PasswordRouter
    {
        private const string prefix = Router.Rule + "Password";
        public const string ResetPassword = prefix + "/resetPassword";


    }
}
