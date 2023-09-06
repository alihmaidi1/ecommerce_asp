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
using ecommerce_shared.Pagination;

namespace Repositories.Brand
{
    public interface IBrandRepository:IgenericRepository<BrandEntity>
    {


        public bool IsNameExists(string Name);
        public bool IsExists(Guid Id);

        public bool IsUniqueName(string Name);

        public Task<BrandEntity> Update(UpdateBrandCommand brand);
        public Task<PageList<AddBrandResponse>> GetAll(string? OrderBy,int? pageNumber, int? pageSize);

        public bool Delete(Guid Id);

    }
}
