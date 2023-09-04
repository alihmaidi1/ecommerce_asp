using ecommerce_shared.Services.Authentication.ResponseAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Services.Authentication
{
    public class GithubAuthenticationService : IAuthenticationService
    {


        public HttpClient HttpClient { get; set; }
        public GithubAuthenticationService(IHttpClientFactory HttpClientFactory)
        {
            this.HttpClient = HttpClientFactory.CreateClient("GithubAuth");

        }

        public async Task<Response> GetUserInfo(string Token)
        {

            HttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Token}");
            HttpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            HttpClient.DefaultRequestHeaders.Add("User-Agent", "Foo");
            var response = await HttpClient.GetFromJsonAsync<GithubResponse>("/user");            
            return GithubResponse.ToDefaultResponse(response);
        }
    }
}
