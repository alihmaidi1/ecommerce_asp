using ecommerce.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;

namespace ecommerce.Domain.Entities
{
    public class Admin : BaseEntity
    {

        public Guid Id { get; set; }
        public Guid AccountId { get; set; }

        public virtual Account Account { get; set; }

        public bool IsBlocked { get; set; }

    }


}