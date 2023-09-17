﻿using BrandEntity=ecommerce.Domain.Entities.Brand;
using Repositories.Base.Concrete;

using ecommerce.infrutructure;
using Repositories.Brand.Store;
using ecommerce.Dto.Results.Admin.Brand;
using ecommerce.models.SuperAdmin.Brand.Commands;
using ecommerce_shared.File;
using ecommerce_shared.File.S3;
using ecommerce_shared.Constant;
using ecommerce_shared.Pagination;
using Repositories.Brand.Operations;
using Nest;
using ecommerce_shared.Enums;
using ecommerce.Domain.ElasticSearch;
using Microsoft.AspNetCore.Hosting;

namespace Repositories.Brand
{
    public class BrandRepository : GenericRepository<BrandEntity>, IBrandRepository
    {
        public IStorageService StorageService;
        public IWebHostEnvironment WebHostEnvironment;
        public IElasticClient ElasticClient;
        public BrandRepository(IWebHostEnvironment WebHostEnvironment,IElasticClient ElasticClient,IStorageService StorageService,ApplicationDbContext DbContext) : base(DbContext)
        {
            this.ElasticClient = ElasticClient;
            this.WebHostEnvironment= WebHostEnvironment;
            this.StorageService = StorageService;
        }

        public bool IsNameExists(string Name)
        {

            return DbContext.Brands.Any(b => b.Name == Name);   
        }


        public async Task<PageList<AddBrandResponse>> GetAll(string? OrderBy, int? pageNumber,int? pageSize)
        {

            var Result = ElasticClient.Search<BrandEntity>(s=>s
                .Index(nameof(ElasticSearchIndexName.brand))
                .Query(q=>q.MatchAll())
                .Sort(s=>s.SortQuery(OrderBy,BrandSorting.switchOrdering))
                .PaginateQuery<BrandEntity>(pageNumber, pageSize)
            );


            if (!Result.IsValid)
            {

                throw new Exception(Result.ServerError.ToString());
            }

           // PageList<AddBrandResponse> Result= await DbContext.Brands
           //     .Sort(OrderBy,BrandSorting.switchOrdering)                
           //     .Select(BrandQuery.ToBrandResponse)
           //     .ToPagedList(pageNumber,pageSize);
           return Result.Documents.Select(BrandQuery.ToBrandResponse.Compile()).ToPaginateResult(Result.HitsMetadata.Total.Value,pageNumber, pageSize);
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
            ElasticClient.Update(DBBrand, ElasticSearchIndexName.brand);            
            return DBBrand;


        }

        public bool IsUniqueName(Guid Id,string Name)
        {

           return !DbContext.Brands.Any(x=>x.Name.Equals(Name)&&x.Id!=Id);

        }



        public bool Delete(Guid Id)
        {
            var brand=new BrandEntity { Id = Id };
            DbContext.Brands.Remove(brand);            
            DbContext.SaveChanges();
            ElasticClient.Delete(brand, ElasticSearchIndexName.brand);
            return true; 

        }

        public bool IsValidLogo(Guid Id, string logo)
        {

            if (FileExtensionLocal.IsImageExists(logo, WebHostEnvironment.WebRootPath))
            {

                return true;

            }

            var brand = DbContext.Brands.FirstOrDefault(x => x.Id == Id);
            if (brand == null)
            {

                return false;
            }
            if(brand.Url==logo)
            {

                return true;
            }

            return false;

        }


        public BrandEntity Get(Guid Id)
        {

            return DbContext.Brands.FirstOrDefault(x=>x.Id==Id);

        }


    }
}
