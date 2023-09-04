using ecommerce.Domain.Entities;
using ecommerce.models.SuperAdmin.Brand.Commands;
using ecommerce_shared.File.S3;
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
        public BrandService(IStorageService StorageService) {
        
            this.StorageService = StorageService;   
        
        }
        public Task<Brand> CreateBrand(AddBrandCommand request)
        {

            StorageService.GetObjectFromS3(request.Image);

            return null;


        }

    }
}
