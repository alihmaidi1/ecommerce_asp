using ecommerce.Domain.Entities;
using ecommerce.Dto.Results.Admin.Brand;
using ecommerce.models.SuperAdmin.Brand.Commands;
using ecommerce_shared.Constant;
using ecommerce_shared.File;
using ecommerce_shared.File.S3;
using Repositories.Brand;
using Repositories.Brand.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.service.BrandService
{
    public class BrandService:IBrandService
    {
        public IStorageService StorageService;
        public IBrandRepository BrandRepository;
        public BrandService(IStorageService StorageService, IBrandRepository BrandRepository) {
        
            this.StorageService = StorageService;   
            this.BrandRepository = BrandRepository;
        
        }
        public async Task<AddBrandResponse> CreateBrand(AddBrandCommand request)
        {

            ImageResponse images=await StorageService.OptimizeFile(request.Image, FolderName.Brand);
            Brand Brand=new Brand();
            Brand.Name=request.Name;
            Brand.Hash = images.hash;
            Brand.Url = images.Url;
            Brand.ResizedUrl = images.resized;
            Brand=await BrandRepository.AddAsync(Brand);
            AddBrandResponse Response= BrandStore.Query.ToBrandResponse.Compile()(Brand);

            return Response;


        }

    }
}
