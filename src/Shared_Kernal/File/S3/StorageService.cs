using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Transfer;
using ecommerce_shared.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Collections;

namespace ecommerce_shared.File.S3
{
    public class StorageService : IStorageService,IDisposable
    {
        private readonly IConfiguration Configration;
        private AmazonS3Client client;
        private bool isDisposed;
        public StorageService(IConfiguration Configration) {
        
            this.Configration = Configration;
        }

        private BasicAWSCredentials GetCredentials()
        {
            var Credentials = Configration.GetSection("S3");
            return new BasicAWSCredentials(Credentials["AccessKey"], Credentials["SecretKey"]);

        }

        private AmazonS3Config GetBucketConfig()
        {
            return new AmazonS3Config()
            {
                RegionEndpoint = Amazon.RegionEndpoint.USEast1

            };

        }


        private TransferUtilityUploadRequest GetRequestUpload(S3Object obj)
        {
            var Credentials = Configration.GetSection("S3");
            return new TransferUtilityUploadRequest()
            {
                InputStream = obj.InputStream,
                Key = obj.Name,
                BucketName = Credentials["BucketName"],
                CannedACL = S3CannedACL.NoACL
            };

        }
        private async Task<bool> UploadFileAsync(S3Object obj)
        {

            var AwsCrediential = GetCredentials();
            var config = GetBucketConfig();
            TransferUtilityUploadRequest uploadRequest = GetRequestUpload(obj);
            client = new AmazonS3Client(AwsCrediential, config);
            var transferUtility = new TransferUtility(client);
            await transferUtility.UploadAsync(uploadRequest);
            return true;


        }

        public async Task<string> UploadToS3(IFormFile file)
        {

            try
            {


                var S3Obj = await GetS3Object(file);
                bool isUploaded=await UploadFileAsync(S3Obj);
                if (!isUploaded)
                {
                    throw new Exception("Can Not Upload Image");

                }

                return Configration.GetRequiredSection("S3")["url"]+$"/{S3Obj.Name}";

            }
            catch(Exception ex)
            {

                throw new Exception(ex.Message);

            }

        }

        public async Task<S3Object> GetS3Object(IFormFile file)
        {
            var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);

            var fileExt = Path.GetExtension(file.FileName);
            var fileName = $"{Guid.NewGuid().ToString()}{fileExt}";

            return new S3Object(){

                Name=fileName,
                InputStream=memoryStream
            };


        }

        ~StorageService()
        {

            Dispose(false);

        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed)
                return;
            this.client.Dispose();
        }

        public async Task<List<string>> UploadFilesToS3(List<IFormFile> Files)
        {
            List<Task<string>> uploadTasks = new List<Task<string>>();
            
            foreach (var file in Files)
            {
                uploadTasks.Add(UploadToS3(file));
            }
            await Task.WhenAll(uploadTasks);
            List<string> result = uploadTasks.Select(t => t.Result).ToList();
            return result;
        }



        public async Task<string> UploadBase64ToS3(string file)
        {
            try
            {

                var Stream = createBase64Stream(file);
                var S3Obj =await GetBase64S3Object(Stream.fileName,Stream.bytes);
                bool isUploaded = await UploadFileAsync(S3Obj);
                if (!isUploaded)
                {
                    throw new Exception("Can Not Upload Image");

                }

                return Configration.GetRequiredSection("S3")["url"] + $"/{S3Obj.Name}";


            }
            catch
            {


                throw new IOStreamException("Cannot Upload Base64 Image");

            }

            
        }

        public async Task<S3Object> GetBase64S3Object(string fileName, byte[] bytes)
        {
            var memoryStream = new MemoryStream(bytes);
            return new S3Object()
            {

                Name = fileName,
                InputStream = memoryStream
            };


        }
        private (string fileName, byte[] bytes) createBase64Stream(string image)
        {
            (string base64, string extension) file = GetBase64Info(image);
            var bytes = Convert.FromBase64String(file.base64);
            string TempDirectory ="Temps";
            if (!Directory.Exists(TempDirectory))
            {
                Directory.CreateDirectory(TempDirectory);
            }
            var uniqueFileName = Guid.NewGuid().ToString() + "." + file.extension;
            string imageName = Guid.NewGuid().ToString() + uniqueFileName;
            string imagePath = TempDirectory+ $"/{imageName}";

            return (imagePath, bytes);
        }


        private  (string base64, string extension) GetBase64Info(string base64File)
        {

            var base64 = base64File.Substring(base64File.IndexOf(",") + 1);
            var ExtensionLength = base64File.IndexOf(";") - base64File.IndexOf("/");
            var extension = base64File.Substring(base64File.IndexOf("/") + 1, ExtensionLength - 1);
            return (base64, extension);
        }


    }
}
