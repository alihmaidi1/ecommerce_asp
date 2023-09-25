﻿using ecommerce.Domain.Entities.City;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.models.SuperAdmin.City.Command
{
    public class ToggleCityCommand:IRequest<JsonResult>
    {

        public CityId Id { get; set; }

    }
}
