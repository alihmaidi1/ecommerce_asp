using ecommerce.Domain.Base.Abstract;
using ecommerce.Domain.Base.Entity;
using ecommerce.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.Entities
{
    public class TageablePivot:BaseEntityWithoutId
    {
        public Guid TagId { get; set; }

        public EntitiesHasTag Type { get; set; }
        public Guid TagableId { get; set; }

    }
}
