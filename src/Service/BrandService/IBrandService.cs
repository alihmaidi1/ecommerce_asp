using ecommerce.Domain.Entities;
using ecommerce.models.SuperAdmin.Brand.Commands;
using ecommerce_shared.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.service.BrandService
{
    public interface IBrandService
    {

        public Task<ImageResponse> CreateBrand(AddBrandCommand request);


    }
}
