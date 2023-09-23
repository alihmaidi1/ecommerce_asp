using CategoryEntity = ecommerce.Domain.Entities.Category.Category;
using Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerce.Dto.Results.Admin.Category;
using ecommerce.Domain.Entities.Category;

namespace Repositories.Category
{
    public interface ICategoryRepository : IgenericRepository<CategoryEntity>
    {

        public bool IsUniqueName(string name);
        public bool IsUniqueName(string name, CategoryId Id);


        public bool IsUniqueRank(int Rank);
        public bool IsUniqueRank(int Rank, CategoryId Id);


        public bool ValidImages(List<string> images, CategoryId Id);

        public bool IsExists(CategoryId? Id);


        public Task<AddCategoryResponse> Store(string Name, string Description, string Meta_Title, int rank, string Meta_Description, CategoryId? ParentId, List<string> Images);

        public Task<AddCategoryResponse> Update(CategoryId Id, string Name, string Description, string Meta_Title, int rank, string Meta_Description, CategoryId? ParentId, List<string> Images, List<string> deletedImages);

        public List<GetAllCategoryResponse> GetCategories();

        public List<GetCategoryResponse> GetCategoryTree();

        public GetCategoryResponse? GetCategory(CategoryId Id);


        public bool UnActive(CategoryId Id);


        public bool Delete(CategoryId Id);

        public bool ActiveCategory(CategoryId Id);



    }
}
