﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.AppMetaData.Admin
{
    public static class RoleRouter
    {

        private const string prefix = Router.Rule + "Role";
        public const string List = prefix + "/GetAllRole";

    }
}