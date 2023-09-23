using ecommerce.Domain.Base.ValueObject;
using ecommerce.Domain.Entities.Brand;
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

        public static implicit operator Guid(CategoryId StronglyId) => StronglyId.Value;
        public static implicit operator CategoryId(Guid value) => new CategoryId(value);

    }
}
