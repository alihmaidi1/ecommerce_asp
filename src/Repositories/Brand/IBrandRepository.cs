//using BrandEntity = ecommerce.Domain.Entities.Brand.Brand;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Repositories.Base;
//using ecommerce.Dto.Results.Admin.Brand;
//using ecommerce.models.SuperAdmin.Brand.Commands;
//using ecommerce_shared.File;
//using ecommerce_shared.Pagination;
//using ecommerce.Domain.Entities.Brand;

//namespace Repositories.Brand
//{
//    public interface IBrandRepository:IgenericRepository<BrandEntity>
//    {


//        public bool IsNameExists(string Name);
//        public bool IsExists(BrandId Id);
//        public bool IsValidLogo(BrandId Id,string logo);


//        public BrandEntity Get(BrandId Id);     

//        public bool IsUniqueName(BrandId Id,string Name);

//        public Task<BrandEntity> Update(UpdateBrandCommand brand);
//        public Task<PageList<AddBrandResponse>> GetAll(string? OrderBy,int? pageNumber, int? pageSize);


//        public bool Delete(BrandId Id);

//    }
//}
