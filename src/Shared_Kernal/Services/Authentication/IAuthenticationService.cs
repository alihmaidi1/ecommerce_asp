using ecommerce_shared.Services.Authentication.ResponseAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Services.Authentication
{
    public interface IAuthenticationService
    {

        public Task<Response> GetUserInfo(string Token);

    }
}
