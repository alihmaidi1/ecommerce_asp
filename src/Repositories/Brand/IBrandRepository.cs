using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandTable=ecommerce.Domain.Entities.BrandEntities.Brand;
using Repositories.Base;
using ecommerce.Dto.Results.Admin.Brand;
using ecommerce.models.SuperAdmin.Brand.Commands;
using ecommerce_shared.File;
using ecommerce_shared.Pagination;

namespace Repositories.Brand
{
    public interface IBrandRepository:IgenericRepository<BrandTable>
    {


        public bool IsNameExists(string Name);
        public bool IsExists(Guid Id);
        public bool IsValidLogo(Guid Id,string logo);


        public BrandTable Get(Guid Id);     

        public bool IsUniqueName(Guid Id,string Name);

        public Task<BrandTable> Update(UpdateBrandCommand brand);
        public Task<PageList<AddBrandResponse>> GetAll(string? OrderBy,int? pageNumber, int? pageSize);


        public bool Delete(Guid Id);

    }
}
