using ecommerce.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;

namespace ecommerce.Domain.Entities.Page
{
    public class Page : BaseEntity<PageId>
    {

        public Page() { 
        
            Id=new PageId(Guid.NewGuid());
        }

        public PageName Name { get; set; }

        public string Content { get; set; }


    }
}
