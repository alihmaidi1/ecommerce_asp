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
        public Task<string> UploadToS3(string filename, MemoryStream file);

        //public Task<List<string>> UploadFilesToS3(List<IFormFile> Files);

        public Task<MemoryStream> GetObjectFromS3(string file);
        

        public Task<ImageResponse> OptimizeFile(string file,string Folder);
        public Task<List<ImageResponse>> OptimizeMany(List<string> files,string Folder);

    }
}
