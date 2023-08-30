using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Swagger
{
    public class ApiGroupAttribute: System.Attribute
    {
        public ApiGroupAttribute(params ApiGroupName[] name)
        {
            GroupName = name;
        }
        public ApiGroupName[] GroupName { get; set; }

    }
}
