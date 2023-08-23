using ecommerce.Domain.Entities;
using ecommerce.infrutructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infrutructure.Services.Classes
{
    internal class ExternalApi : IExternalApi
    {
        public HttpClient HttpClient { get; set; }
        public ExternalApi()
        {
            HttpClient=new HttpClient();

        }

        public async Task<HttpResponseMessage> GetAllCountry()
        {
            HttpRequestMessage GetCountryRequest =MakeGetRequest("https://countriesnow.space/api/v0.1/countries/positions");
            var response=await HttpClient.SendAsync(GetCountryRequest);
            return response;
        }


        public HttpRequestMessage MakeGetRequest(string uri, Dictionary<string,string> data=null)
        {


            return new HttpRequestMessage()
            {

                RequestUri=new Uri(uri),
                Method=HttpMethod.Get,
                Content=new FormUrlEncodedContent(data)

            };
        }

    }
}
