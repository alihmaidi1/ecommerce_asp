using ecommerce_shared.Services.Authentication.ResponseAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Services.Authentication
{
    public class GoogleAuthenticationService : IAuthenticationService
    {

        public HttpClient HttpClient { get; set; }
        public GoogleAuthenticationService(IHttpClientFactory HttpClientFactory)
        {
            this.HttpClient = HttpClientFactory.CreateClient("GoogleAuth");

        }


        
        public async Task<Response> GetUserInfo(string Token)
        {
            var response= await HttpClient.GetFromJsonAsync<Response>($"/oauth2/v3/userinfo?access_token={Token}");
            return response;            
        }
    }
}
