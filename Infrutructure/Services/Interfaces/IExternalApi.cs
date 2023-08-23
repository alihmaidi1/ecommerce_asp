using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infrutructure.Services.Interfaces
{
    public interface IExternalApi
    {
        public Task<HttpResponseMessage> GetAllCountry();

    }
}
