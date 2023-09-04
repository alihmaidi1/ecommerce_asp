using Amazon.Runtime.Internal.Endpoints.StandardLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.File
{
    public class ImageResponse
    {

        public string Url { get; set; }

        public string hash { get; set; }

        public string resized { get; set; }
    }
}
