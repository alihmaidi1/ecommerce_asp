using BrandEntity=ecommerce.Domain.Entities.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Base;
using ecommerce.Dto.Results.Admin.Brand;
using ecommerce.models.SuperAdmin.Brand.Commands;
using ecommerce_shared.File;

namespace Repositories.Brand
{
    public interface IBrandRepository:IgenericRepository<BrandEntity>
    {


        public bool IsNameExists(string Name);
        public bool IsExists(Guid Id);

        public bool IsUniqueName(string Name);

        public Task<BrandEntity> Update(UpdateBrandCommand brand);
        public List<AddBrandResponse> GetAll();

        public bool Delete(Guid Id);

    }
}
