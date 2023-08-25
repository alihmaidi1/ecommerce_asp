using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Swagger
{
    public class GroupInfoAttribute:System.Attribute
    {


        public string Title { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }


    }
}
