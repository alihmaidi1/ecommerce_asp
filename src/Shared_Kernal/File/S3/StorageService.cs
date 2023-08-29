using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Transfer;
using ecommerce_shared.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
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

        public async Task<bool> UploadToS3(IFormFile file)
        {

            try
            {


                var S3Obj = await GetS3Object(file);
                return await UploadFileAsync(S3Obj);

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
    }
}
