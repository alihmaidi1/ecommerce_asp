using Common.Features.Image.Commands.Models;
using ecommerce.Base;
using ecommerce.Domain.AppMetaData.Common;
using ecommerce_shared.Swagger;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers.Common
{
    public class ImageController: ApiController
    {

        [ApiGroup(ApiGroupName.User, ApiGroupName.SuperAdmin, ApiGroupName.DeliveryMan)]


        [HttpPost(ImageRouter.UploadSingle)]
        public async Task<IActionResult> UploadImage(UploadImageCommand commands)
        {

            var response=await this.Mediator.Send(commands);

            return response;


        }
        [HttpPost(ImageRouter.UploadBase64Image)]

        public async Task<IActionResult> UploadBase64Image([FromBody] UploadBase64ImageCommand commands)
        {

            var response=await this.Mediator.Send(commands);
            return response;


        }


        [HttpPost(ImageRouter.UploadImages)]

        public async Task<IActionResult> UploadImages(UploadImagesCommand commands)
        {


            var response=await Mediator.Send(commands);

            return response;

        }



    }
}
