using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Dto.Results.Admin.Category
{
    public class GetCategoryWithParent: GetCategoryResponse
    {
        public Guid ParentId { get; set; }
    }
}
