using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.File.S3
{
    public class S3Object
    {

        public required string Name { get; set; }
        public required MemoryStream InputStream { get; set; }
    }
}
