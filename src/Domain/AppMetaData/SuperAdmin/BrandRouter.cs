using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.AppMetaData.Admin
{
    public static class BrandRouter
    {

        private const string prefix = Router.Rule + "brand";
        public const string Add = prefix + "/store";
        public const string List = prefix + "/list";
        public const string  Update= prefix + "/update";
        public const string Delete= prefix + "/delete";
        public const string Get = prefix + "/{id}/get";



    }
}
