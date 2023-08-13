using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infrutructure.Dto
{
    public  class ExternalRegionDto
    {

        public bool error { get;set; }
        public string msg { get; set; }

        public object data { get; set; } 
    }
}
