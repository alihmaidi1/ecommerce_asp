using Amazon.Runtime;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.File.S3
{
    public interface IStorageService
    {
        public Task<bool> UploadToS3(IFormFile file);

    }
}
