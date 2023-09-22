using Amazon.Runtime.Internal;
using ecommerce.Domain.Entities.Country;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Country.Queries.Models
{
    public class GetCountryQuery : IRequest<JsonResult>
    {

        public CountryId Id { get; set; }


    }
}
