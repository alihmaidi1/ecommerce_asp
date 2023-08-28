using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.AppMetaData.Common
{
    public class ImageRouter
    {

        private const string prefix = Router.Rule + "Image";
        public const string UploadSingle = prefix + "/UploadSingle";
        public const string UploadBase64Image = prefix + "/UploadBase64Image";
        public const string UploadImages = prefix + "/UploadImages";


    }
}
