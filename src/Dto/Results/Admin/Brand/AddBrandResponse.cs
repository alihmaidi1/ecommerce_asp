using ecommerce_shared.File;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Dto.Results.Admin.Brand
{
    public class AddBrandResponse
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }


        public ImageResponse image { get; set; }

    }
}
