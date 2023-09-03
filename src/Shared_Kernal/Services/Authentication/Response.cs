using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Services.Authentication
{
    public class Response
    {
        public string sub { get; set; }

        public string Email { get; set; }

        public bool email_verified { get; set; }

        public Uri Picture { get; set; }

    }
}
