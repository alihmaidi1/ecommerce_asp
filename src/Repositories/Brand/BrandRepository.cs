using BrandEntity=ecommerce.Domain.Entities.Brand;
using Repositories.Base.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerce.infrutructure;
using Repositories.Brand.Store;
using ecommerce.Dto.Results.Admin.Brand;
using ecommerce.models.SuperAdmin.Brand.Commands;
using ecommerce_shared.File;
using ecommerce_shared.File.S3;
using ecommerce_shared.Constant;
using ecommerce_shared.Pagination;
using ecommerce.Domain.Base;
using Repositories.Brand.Operations;
using Repositories.Base;

namespace Repositories.Brand
{
    public class BrandRepository : GenericRepository<BrandEntity>, IBrandRepository
    {
        public IStorageService StorageService;

        public BrandRepository(IStorageService StorageService,ApplicationDbContext DbContext) : base(DbContext)
        {
            this.StorageService = StorageService;
        }

        public bool IsNameExists(string Name)
        {

            return DbContext.Brands.Any(b => b.Name == Name);   
        }


        public async Task<PageList<AddBrandResponse>> GetAll(string? OrderBy, int? pageNumber,int? pageSize)
        {

            PageList<AddBrandResponse> Result= await DbContext.Brands
                .Sort(OrderBy,BrandSorting.switchOrdering)                
                .Select(BrandQuery.ToBrandResponse)
                .ToPagedList(pageNumber,pageSize);
           return Result;
        }

        public bool IsExists(Guid Id)
        {

            return DbContext.Brands.Any(x=>x.Id==Id);

        }

        public async Task<BrandEntity> Update(UpdateBrandCommand brand)
        {

            BrandEntity DBBrand = DbContext.Brands.FirstOrDefault(b => b.Id==brand.Id);
            if (brand.Logo == DBBrand.Url)
            {

                DBBrand.Name = brand.Name;
                DbContext.SaveChanges();
            }
            else
            {
                ImageResponse image = await StorageService.OptimizeFile(brand.Logo,FolderName.Brand);
                DBBrand.Name = brand.Name;
                DBBrand.Url = image.Url;
                DBBrand.ResizedUrl = image.resized;
                DBBrand.Hash=image.hash;
                DbContext.SaveChanges();                
            }
            return DBBrand;


        }

        public bool IsUniqueName(string Name)
        {

           return !DbContext.Brands.Any(x=>x.Name.Equals(Name));

        }



        public bool Delete(Guid Id)
        {

            DbContext.Brands.Remove(new BrandEntity { Id=Id});
            DbContext.SaveChanges();
            return true; 

        }

    }
}
