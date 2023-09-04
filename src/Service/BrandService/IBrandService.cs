using ecommerce.Domain.Entities;
using ecommerce.models.SuperAdmin.Brand.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.service.BrandService
{
    public interface IBrandService
    {

        public Task<Brand> CreateBrand(AddBrandCommand request);


    }
}
