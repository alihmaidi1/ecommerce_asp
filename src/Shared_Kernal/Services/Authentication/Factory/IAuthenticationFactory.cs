using ecommerce_shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Services.Authentication.Factory
{
    public interface IAuthenticationFactory
    {

        public IAuthenticationService CreateAuthenticationService(ProviderAuthentication provider);

    }
}
