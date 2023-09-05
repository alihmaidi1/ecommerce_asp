using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.AppMetaData.Common
{
    public class ImageRouter
    {

        private const string prefix = Router.Rule + "image";
        public const string UploadSingle = prefix + "/uploadSingle";
        public const string UploadBase64Image = prefix + "/uploadBase64Image";
        public const string UploadImages = prefix + "/uploadImages";


    }
}
