using ecommerce_shared.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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

    }
}
