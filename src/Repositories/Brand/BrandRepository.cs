using BrandEntity=ecommerce.Domain.Entities.Brand;
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
using ecommerce.Repository.ElasticSearch;

namespace Repositories.Brand
{
    public class BrandRepository : GenericRepository<BrandEntity>, IBrandRepository
    {
        public IStorageService StorageService;
        public IElasticSearch ElasticSearch;
        public IElasticClient ElasticClient;
        public BrandRepository(IElasticClient ElasticClient,IElasticSearch ElasticSearch, IStorageService StorageService,ApplicationDbContext DbContext) : base(DbContext)
        {
            this.ElasticClient = ElasticClient;
            this.StorageService = StorageService;
            this.ElasticSearch=ElasticSearch;
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
            ElasticSearch.Update(DBBrand, ElasticSearchIndexName.brand);            
            return DBBrand;


        }

        public bool IsUniqueName(string Name)
        {

           return !DbContext.Brands.Any(x=>x.Name.Equals(Name));

        }



        public bool Delete(Guid Id)
        {
            var brand=new BrandEntity { Id = Id };
            DbContext.Brands.Remove(brand);            
            DbContext.SaveChanges();
            ElasticSearch.Delete(brand, ElasticSearchIndexName.brand);
            return true; 

        }

    }
}
