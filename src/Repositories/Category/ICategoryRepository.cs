using CategoryEntity=ecommerce.Domain.Entities.Category;
using Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerce.Dto.Results.Admin.Category;

namespace Repositories.Category
{
    public interface ICategoryRepository:IgenericRepository<CategoryEntity>
    {
        
        public bool IsUniqueName(string name);
        public bool IsUniqueName(string name,Guid Id);


        public bool IsUniqueRank(int Rank);
        public bool IsUniqueRank(int Rank,Guid Id);


        public bool ValidImages(List<string>images,Guid Id);

        public bool IsExists(Guid ?Id);


        public Task<AddCategoryResponse> Store(string Name,string Description,string Meta_Title, int rank,string Meta_Description,Guid? ParentId,List<string>Images);

        public Task<AddCategoryResponse> Update(Guid Id,string Name, string Description, string Meta_Title, int rank, string Meta_Description, Guid? ParentId, List<string> Images, List<string> deletedImages);
        
        public List<GetAllCategoryResponse> GetCategories();

        public List<GetCategoryResponse> GetCategoryTree();

        public GetCategoryResponse? GetCategory(Guid Id);


        public bool UnActive(Guid Id);


        public bool Delete(Guid Id);    

        public bool ActiveCategory(Guid Id);    



    }
}
