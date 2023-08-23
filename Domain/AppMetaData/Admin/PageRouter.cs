using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.AppMetaData.Admin
{


    public static class PageRouter
    {
        private const string prefix = Router.Rule+"Page";
        public const string List = prefix + "/List";
        public const string GetById = prefix + "/{id}/GetById";
        public const string AddPage = prefix + "/store";
        public const string Delete = prefix + "/{id}/Delete";


    }
}
