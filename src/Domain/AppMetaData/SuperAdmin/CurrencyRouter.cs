using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.AppMetaData.SuperAdmin
{

    public static class CurrencyRouter
    {

        private const string prefix = Router.Rule + "currency";

        public const string List = prefix + "/list";
        public const string Toggle = prefix + "/{id:guid}/toggle";




    }
}
