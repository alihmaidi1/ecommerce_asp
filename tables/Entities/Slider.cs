using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;

namespace tables.Entities
{
    internal class Slider :BaseEntity
    {
        public string Url { get; set; }
        public string Rank { get; set; }
        public bool  Status { get; set; }=true;

    }
}
