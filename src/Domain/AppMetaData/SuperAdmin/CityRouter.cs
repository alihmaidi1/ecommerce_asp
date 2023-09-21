using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.AppMetaData.SuperAdmin
{
    public static class CityRouter
    {

        private const string prefix = Router.Rule + "city";

        public const string Toggle = prefix + "/{id:guid}/toggle";

    }
}
