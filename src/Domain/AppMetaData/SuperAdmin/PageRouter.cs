using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.AppMetaData.Admin
{


    public static class PageRouter
    {
        private const string prefix = Router.Rule+"page";
        public const string List = prefix + "/list";
        public const string GetById = prefix + "/{id}/getById";
        public const string AddPage = prefix + "/store";
        public const string Delete = prefix + "/{id}/delete";


    }
}
