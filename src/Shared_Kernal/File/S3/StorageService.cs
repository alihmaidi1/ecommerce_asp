using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using ecommerce_shared.Constant;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;


namespace ecommerce_shared.File.S3
{
    public class StorageService : IStorageService,IDisposable
    {
        private readonly IConfiguration Configration;
        private AmazonS3Client client;
        private AmazonS3Config BucketConfig;
        private string wwwroot;
        public string host;
        public string awsUrl;

        private BasicAWSCredentials BasicAWSCredentials;
        private bool isDisposed;
        public StorageService(IWebHostEnvironment webhostEnvironment,IConfiguration Configration) {
        
            this.Configration = Configration;
            this.wwwroot = webhostEnvironment.WebRootPath;
            this.host = Configration.GetValue<string>("host");
            this.awsUrl = Configration.GetRequiredSection("S3")["url"];

        }

        private BasicAWSCredentials GetCredentials()
        {

            var Credentials = Configration.GetSection("S3");
            BasicAWSCredentials=new BasicAWSCredentials(Credentials["AccessKey"], Credentials["SecretKey"]);
            return BasicAWSCredentials;
        }

        private AmazonS3Config GetBucketConfig()
        {

            BucketConfig= new AmazonS3Config()
            {
                RegionEndpoint = Amazon.RegionEndpoint.USEast1

            };
            return BucketConfig;

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
            var client = new AmazonS3Client(AwsCrediential, config);
            var transferUtility = new TransferUtility(client);                        
            await transferUtility.UploadAsync(uploadRequest);
            return true;


        }
        
        private async Task<GetObjectResponse> GetObjectResponse(string file)
        {

            var AwsCrediential = GetCredentials();
            var Credentials = Configration.GetSection("S3");
            var config = GetBucketConfig();
            var client = new AmazonS3Client(AwsCrediential, config);
            GetObjectResponse response = await client.GetObjectAsync(Credentials["BucketName"], file);

            return response;

        }

        public async Task<MemoryStream> GetObjectFromS3(string file)
        {
            var response= await GetObjectResponse(file);
            MemoryStream memoryStream = new MemoryStream();
            using (Stream responseStream = response.ResponseStream)
            {
                responseStream.CopyTo(memoryStream);
            }

            return memoryStream;

        }



        public async Task<ImageResponse> OptimizeFile(string file,string Folder)
        {

            string splitfile = Path.GetFileName(file);            
            string fullpath = Path.Combine(wwwroot,FolderName.Temp,splitfile);
            string newpath=Folder+"/"+Guid.NewGuid()+Path.GetExtension(splitfile);
            using var Filestream = new FileStream(fullpath,FileMode.Open);
            var hash = Filestream.GetImageHash();
            var resized = (Filestream).resizeImage(Folder, 400, 400);

            Filestream.Position= 0;
            using MemoryStream memoryStream = new MemoryStream();
            Filestream.CopyTo(memoryStream);

            var rezisedimage= UploadToS3(resized.imagefile, resized.memorystream);
            var uploadedfile =  UploadToS3(newpath, memoryStream);
            var result= await Task.WhenAll(rezisedimage, uploadedfile);
            List<string> images = result.ToList();
            return new ImageResponse
            {
                Url=result.First(),
                hash=hash,
                resized=result.Last()
                
            };
        }



        public async Task<List<ImageResponse>> OptimizeMany(List<string> files, string Folder)
        {
            List<Task<ImageResponse>> optimizeTasks = new List<Task<ImageResponse>>();
            foreach (var file in files)
            {
                optimizeTasks.Add(OptimizeFile(file, Folder));
            }
            var result1=await Task.WhenAll(optimizeTasks);
            List<ImageResponse> result = result1.ToList();
            return result;

            }




        public async Task<string> UploadToS3(string filename,MemoryStream file)
        {

            try
            {


                var S3Obj = GetS3Object(filename,file);                
                bool isUploaded=await UploadFileAsync(S3Obj);
                if (!isUploaded)
                {
                    throw new Exception("Can Not Upload Image");
                }

                return awsUrl+$"/{filename}";

            }
            catch(Exception ex)
            {

                throw new Exception(ex.Message);

            }

        }

        public  S3Object GetS3Object(string filename,MemoryStream file)
        {

            return new S3Object(){

                Name=filename,
                InputStream=file
            };


        }

        
        //public async Task<List<string>> UploadFilesToS3(List<IFormFile> Files)
        //{
        //    List<Task<string>> uploadTasks = new List<Task<string>>();
            
        //    foreach (var file in Files)
        //    {
        //        uploadTasks.Add(UploadToS3(file));
        //    }
        //    await Task.WhenAll(uploadTasks);
        //    List<string> result = uploadTasks.Select(t => t.Result).ToList();
        //    return result;
        //}



        



       

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
            this.client?.Dispose();
        }


    }
}
