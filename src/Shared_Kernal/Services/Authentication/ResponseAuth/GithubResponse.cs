using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Services.Authentication.ResponseAuth
{
    public class GithubResponse
    {

        public int id { get; set; }

        public string Email { get; set; }

        public Uri avatar_url { get; set; }


        public static Func<GithubResponse, Response> ToDefaultResponse = (response) =>
        {

            return new Response
            {

                Email = response.Email,
                Picture = response.avatar_url,
                sub = response.id.ToString(),
            };


        };

    }
}
