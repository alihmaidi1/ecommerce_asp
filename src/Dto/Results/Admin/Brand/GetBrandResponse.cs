using ecommerce_shared.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Dto.Results.Admin.Brand
{
    public class GetBrandResponse
    {

        public Guid Id { get; set; }
        public string Name { get; set; }    
        public ImageResponse image { get; set; }

    }
}
