using ecommerce.admin.Features.Auth.Commands.Models;
using BrandEntity=ecommerce.Domain.Entities.Brand;
using ecommerce.models.SuperAdmin.Brand.Commands;
using ecommerce.service.BrandService;
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

        public IBrandService BrandService;
        public BrandHandler(IBrandService BrandService) { 
        

            this.BrandService = BrandService;
        }   
        

        public async Task<JsonResult> Handle(AddBrandCommand request, CancellationToken cancellationToken)
        {

            //ImageResponse image= await StorageService.OptimizeFile(request.Image);
            ImageResponse Brand =await BrandService.CreateBrand(request);
            return Success(Brand,"The Brand Was Created Successfully");
            //return Success(image, "suucess");
        }
    }
}
