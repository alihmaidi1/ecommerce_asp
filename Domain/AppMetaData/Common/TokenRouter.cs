using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.AppMetaData.Common
{
    public static class TokenRouter
    {

        private const string prefix = Router.Rule + "Token";
        public const string RefreshTheToken = prefix + "/refresh";


    }
}
