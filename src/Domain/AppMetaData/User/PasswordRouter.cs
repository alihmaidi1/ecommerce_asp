using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.AppMetaData.User
{
    public static class PasswordRouter
    {


        private const string prefix = Router.Rule + Router.User + "Password";
        public const string ResetEmail = prefix + "/ResetEmail";
        public const string CheckCode = prefix + "/CheckCode";

    }
}
