using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.AppMetaData.Admin
{
    public static class RoleRouter
    {

        private const string prefix = Router.Rule + "role";
        public const string List = prefix + "/getAllRole";
        public const string Get = prefix + "/{id}/get";
        public const string Permissions = prefix + "/permissions";
        public const string Store = prefix + "/store";
        public const string Update= prefix + "/update";
        public const string Delete= prefix + "/{Id:guid}/delete";




    }
}
