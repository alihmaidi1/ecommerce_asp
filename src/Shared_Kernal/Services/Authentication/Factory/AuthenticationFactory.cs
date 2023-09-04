using ecommerce_shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Services.Authentication.Factory
{
    public class AuthenticationFactory : IAuthenticationFactory
    {
        public IHttpClientFactory httpClientFactory;
        public AuthenticationFactory(IHttpClientFactory httpClientFactory) { 
        

            this.httpClientFactory = httpClientFactory;
        }  
        public IAuthenticationService CreateAuthenticationService(ProviderAuthentication provider)
        {

            
            if(provider==ProviderAuthentication.Google)
            {

                return new GoogleAuthenticationService(httpClientFactory);

            }
            else if(provider==ProviderAuthentication.Git)
            {

                return new GithubAuthenticationService(httpClientFactory);
            }
            throw new Exception("The Provider Is Not Valid");

        }


    }
}
