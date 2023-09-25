using ecommerce.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.Base.ValueObject
{
    public class StronglyTypeId : ValueObject
    {

        public Guid Value;

        public StronglyTypeId(Guid Value) {
            this.Value = Value;
        }

        
        public override IEnumerable<object> GetValues()
        {
            yield return Value;
        }
    }
}
