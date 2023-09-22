using ecommerce.Domain.Base.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.Entities.Category
{
    public class CategoryId : StronglyTypeId
    {
        public CategoryId(Guid Value) : base(Value)
        {
        }
    }
}
