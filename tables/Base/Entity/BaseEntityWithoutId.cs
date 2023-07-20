using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;

namespace ecommerce.Domain.Base.Entity
{
    public class BaseEntityWithoutId:IBaseEntity
    {
        public DateTime DateCreated { get; set; }
        public DateTime? DateDeleted { get; set; }
        public DateTime? DateUpdated { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public Guid? DeletedBy { get; set; }
    }
}
