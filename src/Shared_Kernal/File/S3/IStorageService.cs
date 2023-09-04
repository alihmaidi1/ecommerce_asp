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
        public Task<string> UploadToS3(IFormFile file);

        public Task<string> UploadBase64ToS3(string file);
        public Task<List<string>> UploadFilesToS3(List<IFormFile> Files);

        public Task<MemoryStream> GetObjectFromS3(string file);
        public Task<bool> CheckObjectExists(string file);


        public Task<ImageResponse> OptimizeFile(string file);

    }
}
