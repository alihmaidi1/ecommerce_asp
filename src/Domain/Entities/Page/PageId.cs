using ecommerce.Domain.Base.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.Entities.Page
{
    public class PageId : StronglyTypeId
    {
        public PageId(Guid Value) : base(Value)
        {
        }
    }
}
