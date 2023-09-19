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
        public bool IsUniqueRank(int Rank);


        public bool IsExists(Guid ?Id);

        public Task<AddCategoryResponse> Store(string Name,string Description,string Meta_Title, int rank,string Meta_Description,Guid? ParentId,List<string> Tag,List<string>Images);
    }
}
