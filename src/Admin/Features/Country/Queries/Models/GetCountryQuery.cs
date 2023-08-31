﻿using Amazon.Runtime.Internal;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Features.Country.Queries.Models
{
    public class GetCountryQuery:IRequest<JsonResult>
    {

        [FromRoute]
        public Guid Id { get; set; }


    }
}