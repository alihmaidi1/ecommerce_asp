using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.AppMetaData.SuperAdmin
{
    public static class AdminRouter
    {

        private const string prefix = Router.Rule + Router.Admin + "/admin";
        public const string Store = prefix + "/store";
        public const string Update = prefix + "/update";

        public const string GetAll = prefix + "/all";
        public const string Get = prefix + "/{Id:guid}/get";

        public const string Block = prefix + "/{Id:guid}/block";
        public const string UnBlock = prefix + "/{Id:guid}/Unblock";




    }
}
