using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Authorization.Requirements
{
    public class PermissionRequirement:IAuthorizationRequirement
    {

        public string Permission { get; set; }    


        public PermissionRequirement(string Permission)
        {
            this.Permission = Permission;   

        }

    }
}
