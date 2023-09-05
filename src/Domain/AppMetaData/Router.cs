using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.AppMetaData
{
    public static class Router
    {

        public const string root= "api";
        public const string Version = "v1";
        public const string Rule=root+"/"+Version+"/";

        public const string User = "user";
        public const string Admin = "admin";


    }
}
