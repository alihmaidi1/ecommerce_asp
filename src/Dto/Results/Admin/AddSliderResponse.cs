using ecommerce_shared.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Dto.Results.Admin
{
    public class AddSliderResponse
    {

        public Guid Id { get; set; }

        public ImageResponse image { get; set; }

        public int Rank { get; set; }

    }
}
