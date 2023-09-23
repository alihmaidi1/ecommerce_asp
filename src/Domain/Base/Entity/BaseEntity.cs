using ecommerce.Domain.Base.Entity;
using ecommerce.Domain.Base.ValueObject;
using ecommerce.Domain.Entities.Brand;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tables.Base.Entity
{
    public class BaseEntity<TKey> : BaseEntityWithoutId  where TKey : StronglyTypeId
    {

        public TKey Id { get; set; }

    }
}
