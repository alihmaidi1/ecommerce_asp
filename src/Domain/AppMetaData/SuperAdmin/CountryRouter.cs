using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.AppMetaData.Admin
{
    public static class CountryRouter
    {
        private const string prefix = Router.Rule + "country";
        public const string List = prefix + "/list";

        public const string Get = prefix + "/{id:guid}/get";

    }
}
