using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Dto.Results.Admin.Brand
{
    public class AddBrandResponse
    {

        public Guid Id { get; set; }

        public string Name { get; set; }    

        public string hash { get; set; }

        public string Url { get; set; }

        public string ResizeUrl { get; set; }

    }
}
