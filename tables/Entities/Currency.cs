using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;

namespace tables.Entities
{
    public class Currency : BaseEntity
    {
        public string Code { get; set; }    
        public string Name { get; set; }
        public string Status { get; set; }

    }
}
