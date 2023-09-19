using CategoryEntity=ecommerce.Domain.Entities.Category;
using Repositories.Base.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerce.infrutructure;
using ecommerce.Domain.Entities;
using ecommerce_shared.File.S3;
using ecommerce_shared.File;
using ecommerce_shared.Constant;
using ecommerce.Dto.Results.Admin.Category;
using Repositories.Category.Operations;

namespace Repositories.Category
{
    public class CategoryRepository :  GenericRepository<CategoryEntity>, ICategoryRepository
    {
        public IStorageService StorageService;
        public CategoryRepository(IStorageService StorageService,ApplicationDbContext DbContext) : base(DbContext)
        {
            this.StorageService = StorageService;
        
        }

        public bool IsUniqueName(string name)
        {


            return !DbContext.Categories.Any(c=>c.Name.Equals(name));


        }

        public bool IsUniqueRank(int Rank)
        {


            return !DbContext.Categories.Any(c => c.Rank==Rank);



        }


        public bool IsExists(Guid? Id)
        {
            if(Id==null) return true;
            return DbContext.Categories.Any(x=>x.Id==Id);

        }



        public async Task<AddCategoryResponse> Store(string Name, string Description, string Meta_Title, int rank, string Meta_Description, Guid? ParentId, List<string> Tag, List<string> Images)
        {


            CategoryEntity Category = new CategoryEntity
            {
                Name= Name,
                Description= Description,
                Meta_Title= Meta_Title,
                Meta_Description= Meta_Description,
                Rank= rank,
                ParentId=ParentId,                                
            };
            Tag.ForEach(item =>
            {
                Category.Tags.Add(new Tag { Name=item});
            });
            List<ImageResponse> images = await StorageService.OptimizeMany(Images, FolderName.Category);
            images.ForEach(item =>
            {
                Category.Images.Add(new Image { Url=item.Url,Hash=item.hash,Resized=item.resized});

            });
            DbContext.Categories.Add(Category);            
            DbContext.SaveChanges();
            return CategoryQuery.ToCategoryResponse.Compile()(Category);

        }



    }
}
