using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.AppMetaData.Admin
{
    public static class CountryRouter
    {
        private const string prefix = Router.Rule + "Country";
        public const string List = prefix + "/List";

        public const string Get = prefix + "/{id}/Get";

    }
}
