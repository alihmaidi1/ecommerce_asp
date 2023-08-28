
using Common.Features.Image.Commands.Models;
using ecommerce_shared.File;
using ecommerce_shared.OperationResult;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Common.Features.Image.Commands.Handlers
{
    public class ImageHandlers : OperationResult,
                                 IRequestHandler<UploadImageCommand, JsonResult>,
                                 IRequestHandler<UploadBase64ImageCommand, JsonResult>,
                                 IRequestHandler<UploadImagesCommand, JsonResult>

    {

        private readonly IWebHostEnvironment webHost;
        public ImageHandlers(IWebHostEnvironment webHost) { 
        

            this.webHost = webHost;
        }
        public async Task<JsonResult> Handle(UploadImageCommand request, CancellationToken cancellationToken)
        {

            var image = request.Image.UploadImage(webHost.WebRootPath);
            return Success(image,"The Image Was Uploaded Successfully");

        }

        public async Task<JsonResult> Handle(UploadBase64ImageCommand request, CancellationToken cancellationToken)
        {

            var image = request.Image.UploadBase64Image(webHost.WebRootPath);
            return Success(image,"The Image Was Uploaded Successfully");
        }

        public async Task<JsonResult>  Handle(UploadImagesCommand request, CancellationToken cancellationToken)
        {
            var images = request.images.UploadImages(webHost.WebRootPath);
            return Success(images, "The Images Was Uploaded Successfully");
        }
    }
}
