using ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ecommerce.infrutructure.Dto
{
    public  class ExternalRegionDto<T>
    {

        public bool error { get;set; }
        public string msg { get; set; }

        public T data { get; set; } 


    }



}
