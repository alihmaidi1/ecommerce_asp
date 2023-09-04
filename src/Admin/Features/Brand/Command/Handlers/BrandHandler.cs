using ecommerce.admin.Features.Auth.Commands.Models;
using ecommerce.models.SuperAdmin.Brand.Commands;
using ecommerce_shared.File;
using ecommerce_shared.File.S3;
using ecommerce_shared.OperationResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Features.Brand.Command.Handlers
{
    public class BrandHandler : OperationResult,
        IRequestHandler<AddBrandCommand, JsonResult>

    {

        public IStorageService StorageService;
        public BrandHandler(IStorageService StorageService) {
        
            this.StorageService = StorageService;
        }   


        public async Task<JsonResult> Handle(AddBrandCommand request, CancellationToken cancellationToken)
        {

            ImageResponse image= await StorageService.OptimizeFile(request.Image);

            return Success(image, "suucess");
        }
    }
}
