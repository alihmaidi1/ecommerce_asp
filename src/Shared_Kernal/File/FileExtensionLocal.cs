using Blurhash.ImageSharp;
using ecommerce_shared.Exceptions;
using LazZiya.ImageResize;
using Microsoft.AspNetCore.Http;
using System.Drawing;
using System.Drawing.Imaging;

namespace ecommerce_shared.File
{
    public static class FileExtensionLocal
    {

        public static string UploadImage(this IFormFile image,string WebRootPath)
        {
            try
            {
                var imagePath = image.GetImagePath(WebRootPath);
                using FileStream fileStream = new FileStream(imagePath, FileMode.Create);
                image.CopyTo(fileStream);
                return imagePath;

            }
            catch (Exception ex)
            {
                throw new IOStreamException(ex.Message);
            }


        }



        public static string GetImagePath(this IFormFile image,string WebRootPath)
        {

            string TempDirectory = Path.Combine(WebRootPath, "Temps");
            if (!Directory.Exists(TempDirectory))
            {
                Directory.CreateDirectory(TempDirectory);
            }
            string imageName = Guid.NewGuid().ToString() + image.FileName;
            string imagePath = Path.Combine(TempDirectory, imageName);

            return imagePath; 

        }


        public static string UploadBase64Image(this string image, string WebRootPath)
        {

            try
            {
                var Stream=image.createBase64Stream(WebRootPath);
                using FileStream fileStream = new FileStream(Stream.fileName, FileMode.Create);

                fileStream.Write(Stream.bytes,0, Stream.bytes.Length);
                return Stream.fileName; 


            }
            catch
            {
                throw new IOStreamException("Cannot Upload Base64 Image");
            }


        }


        private static (string fileName, byte[] bytes) createBase64Stream(this string image,string WebRootPath)
        {
            (string base64, string extension) file = image.GetBase64Info();
            var bytes = Convert.FromBase64String(file.base64);
            string TempDirectory = Path.Combine(WebRootPath, "Temps");
            if (!Directory.Exists(TempDirectory))
            {
                Directory.CreateDirectory(TempDirectory);
            }
            var uniqueFileName = Guid.NewGuid().ToString() + "." + file.extension;
            string imageName = Guid.NewGuid().ToString() + uniqueFileName;
            string imagePath = Path.Combine(TempDirectory, imageName);


            return (imagePath,bytes);
        }


        public static (string base64, string extension) GetBase64Info(this string base64File)
        {

            var base64 = base64File.Substring(base64File.IndexOf(",") + 1);
            var ExtensionLength= base64File.IndexOf(";") - base64File.IndexOf("/");
            var extension = base64File.Substring(base64File.IndexOf("/") + 1, ExtensionLength - 1);
            return (base64, extension);
        }



        public static List<string> UploadImages(this List<IFormFile>images, string webRootPath) 
        {

            List<string> UploadedImages=Enumerable.Empty<string>().ToList();

            images.ForEach(image =>
            {

                string imagePath = UploadImage(image, webRootPath);
                UploadedImages.Add(imagePath);

            });
            
            return UploadedImages;

        }


        public static bool IsBase64Image(this string base64File)
        {

            var base64 = base64File.Substring(base64File.IndexOf(",") + 1);
            Span<byte> buffer = new Span<byte>(new byte[base64.Length]);
            return Convert.TryFromBase64String(base64,buffer,out int bytesParsed);

        }

        public static string GetImageHash(this MemoryStream imagepath)
        {
            try
            {
                
                var imageStream = SixLabors.ImageSharp.Image.Load<Rgb24>(imagepath.GetBuffer());
                return Blurhasher.Encode(imageStream, 4, 3);
            }
            catch(Exception ex) 
            {
                throw new IOException(ex.Message);
            }
        }


        public static (string filename,MemoryStream MemoryStream) resizeImage(this MemoryStream imagepath,int Width=300,int Height = 300)
        {
            try
            {

                
                var img = System.Drawing.Image.FromStream(imagepath);
                var imageResized = ImageResize.Scale(img, Width, Height);                                 
                var resizepath = Guid.NewGuid().ToString() + ".png";
                 MemoryStream memoryStream = new MemoryStream();
                imageResized.Save(memoryStream,ImageFormat.Png);
                return (resizepath,memoryStream);

            }
            catch 
            {

                throw new Exception("Cannot resize image");

            }

        }


    }
}
