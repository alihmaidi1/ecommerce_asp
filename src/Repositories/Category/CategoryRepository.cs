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
using ecommerce_shared.Pagination;
using ecommerce.Dto.Results.Admin.Category;
using Repositories.Category.Operations;
using Microsoft.EntityFrameworkCore;
using EFCore.BulkExtensions;
using Repositories.Base;
using StackExchange.Redis;

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

        public bool IsUniqueName(string name, Guid Id)
        {


            return !DbContext.Categories.Any(c => c.Name.Equals(name)&& c.Id!=Id);

        }


        public bool IsUniqueRank(int Rank, Guid Id)
        {


            return !DbContext.Categories.Any(c => c.Rank == Rank && c.Id != Id) ;

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





        public async Task<AddCategoryResponse> Store(string Name, string Description, string Meta_Title, int rank, string Meta_Description, Guid? ParentId, List<string> Images)
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
            List<ImageResponse> images = await StorageService.OptimizeMany(Images, FolderName.Category);
            images.ForEach(item =>
            {
                Category.Images.Add(new ImageCategory { Url=item.Url,Hash=item.hash,Resized=item.resized});

            });
            DbContext.Categories.Add(Category);            
            DbContext.SaveChanges();
            return CategoryQuery.ToCategoryResponse.Compile()(Category);

        }


        public async Task<AddCategoryResponse> Update(Guid Id, string Name, string Description, string Meta_Title, int rank, string Meta_Description, Guid? ParentId,  List<string> Images, List<string> deletedImages)
        {



            CategoryEntity Category = DbContext.
                Categories.
                Include(x=>x.Images).
                First(x=>x.Id==Id);


            Category.Name = Name;
            Category.Description = Description;
            Category.Meta_Title = Meta_Title;
            Category.Meta_Description = Meta_Description;
            Category.Rank = rank;
            Category.ParentId = ParentId;


            List<ImageCategory> oldImages= new List<ImageCategory>();
            Category.Images.ToList().ForEach(item =>
            {

                if (!deletedImages.Any(x=>x.Equals(item.Url)))
                {
                    oldImages.Add(item);

                }


            });
            Category.Images.Clear();

            List<ImageResponse> images = await StorageService.OptimizeMany(Images, FolderName.Category);
            images.ForEach(item =>
            {
                Category.Images.Add(new ImageCategory { Url = item.Url, Hash = item.hash, Resized = item.resized });

            });
            oldImages.ForEach(item =>
            {

                Category.Images.Add(item);


            });


            DbContext.Categories.Update(Category);
            DbContext.SaveChanges();
            return CategoryQuery.ToCategoryResponse.Compile()(Category);







        }



        public PageList<GetAllCategoryResponse> GetCategories(string? OrderBy,int? pageNumber, int? pageSize,bool status=true)
        {


            return DbContext.Categories
                .Where(x=>x.Status==status)
                .Sort(OrderBy,CategorySorting.switchOrdering)
                .Select(CategoryQuery.ToAllCategoryResponse)
                .ToPagedList(pageNumber,pageSize);

            
        }


        public bool ValidImages(List<string> images, Guid Id)
        {

            List<string> DBimages = DbContext.
                Categories.
                Include(x => x.Images)
                .Select(x=>new {images= x.Images.Select(x => x.Url).ToList() ,Id=x.Id})
                .First(x => x.Id == Id).images;

            return images.All(i => DBimages.Any(di => i.Equals(di)));


        }



        public List<GetCategoryResponse> GetCategoryTree(string ? OrderBy="default",bool ? Status=true)
        {

            List<GetCategoryWithParent> AllCategories = DbContext.
                Categories.Where(x=>x.Status==(Status??true))
                .Sort(OrderBy,CategorySorting.switchOrdering).
                Select(CategoryQuery.ToAllCategoryWithParent).ToList();

            List<GetCategoryResponse> RootCategories = GetRootCategory(AllCategories);
            
            return FormatAsTree(RootCategories,AllCategories);

        }


        private List<GetCategoryResponse> FormatAsTree(List<GetCategoryResponse>RootCategories,List<GetCategoryWithParent> AllCategories)
        {

            List<GetCategoryResponse> NewCategoryList=Enumerable.Empty<GetCategoryResponse>().ToList();
            foreach (var category in RootCategories)
            {
                
                category.Childs= AllCategories.Where(c=>c.ParentId==category.Id).Cast<GetCategoryResponse>().ToList();
                if(category.Childs.Any())
                {
                    category.Childs=FormatAsTree(category.Childs, AllCategories);


                }


                NewCategoryList.Add(category);



            }
            
            return NewCategoryList;


        }
    
        
        private List<GetCategoryResponse> GetRootCategory(List<GetCategoryWithParent> Categories)
        {

            List<GetCategoryResponse> RootCategories=Enumerable.Empty<GetCategoryResponse>().ToList();

            Categories.ForEach(category =>
            {
                if (category.ParentId == null)
                    RootCategories.Add(category);

            });

            return RootCategories.Cast<GetCategoryResponse>().ToList();


            

        }



        public GetCategoryResponse GetCategory(Guid Id)
        {

            List<GetCategoryResponse> Categories=GetCategoryTree();
            GetCategoryResponse? result = GetCategoryFromTree(Categories, Id);


            return result;

        }

        private GetCategoryResponse? GetCategoryFromTree(List<GetCategoryResponse> RootCategories,Guid Id)
        {

            GetCategoryResponse? result;
            foreach(var category in RootCategories) {
            
            
                if(category.Id==Id)
                    return category;

                if (category.Childs.Any())
                {

                    result = GetCategoryFromTree(category.Childs, Id);
                    if (result != null)
                    {


                        return result;

                    }



                }
            }


            return null;
        }


        public bool UnActive(Guid Id)
        {

            List<Guid> Ids = Enumerable.Empty<Guid>().ToList();
            GetCategoryResponse category=GetCategory(Id);
            Ids.Add(category.Id);
            Ids.AddRange(GetChildsIds(category));

            DbContext.Categories.Where(x => Ids.Any(id => id == x.Id)).ExecuteUpdate(setter =>            

                setter.SetProperty(p => p.Status, false)

            );

            return true;


        }

        private List<Guid> GetChildsIds(GetCategoryResponse category)
        {

            List<Guid> Ids=Enumerable.Empty<Guid>().ToList();
            foreach(var child in category.Childs)
            {

                Ids.Add(child.Id);
                foreach(var innerChild in child.Childs)
                {
                    Ids.AddRange(GetChildsIds(innerChild));

                    
                }


            }

            return Ids;


        }


        public bool ActiveCategory(Guid Id)
        {

           DbContext.Categories.Where(x => x.Id == Id).ExecuteUpdate(setter =>            
            setter.SetProperty(p=>p.Status,true)                        
            );

            return true;
        }





        public bool Delete(Guid Id)
        {
            List<Guid> Ids = Enumerable.Empty<Guid>().ToList();
            Ids.Add(Id);
            GetCategoryResponse category=GetCategory(Id);
            Ids.AddRange(GetChildsIds(category));
            List<Guid> ProductIds = Enumerable.Empty<Guid>().ToList();
            DbContext.Categories
                .Where(x => Ids.Any(y => y == x.Id))
                .ExecuteUpdate(setter => 
                    setter.SetProperty(p=>p.DateDeleted,DateTime.Now));
            DbContext
                .Products
                .Where(x => x.DateDeleted != null && Ids.Any(y => y == x.Id))
                .ExecuteUpdate(setter=>setter.SetProperty(p=>p.DateDeleted,DateTime.Now));
            // DbContext.Categories.Where(x => x.Id == Id).ExecuteDelete();
            return true;



        }


    }
}
