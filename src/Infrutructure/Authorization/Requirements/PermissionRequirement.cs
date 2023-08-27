using Microsoft.AspNetCore.Authorization;

namespace ecommerce.infrutructure.Authorization.Requirements
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
