using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.AppMetaData.User
{
    public static class PasswordRouter
    {


        private const string prefix = Router.Rule + Router.User + "password";
        public const string ResetEmail = prefix + "/resetEmail";
        public const string CheckCode = prefix + "/checkCode";
        public const string ChangePassword = prefix + "/changePassword";


    }
}
