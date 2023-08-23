using ecommerce.Domain.Base.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tables.Base.Entity
{
    public class BaseEntity : BaseEntityWithoutId
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }



        public override bool Equals(object? obj)
        {
            return true;
            if(obj == null) return false;

            BaseEntity other = obj as BaseEntity;   
            if(ReferenceEquals(this, obj)) return true;
            return this.Id == other.Id;
        }

    }
}
