using ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;

namespace ecommerce.Domain.Entities.Slider
{
    public class Slider :BaseEntity<SliderId>
    {

        public Slider() {

            Id = new SliderId(Guid.NewGuid());
        
        }
        public string Url { get; set; }
        public string Hash { get; set; }
        public string ResizedUrl { get; set; }
        public int Rank { get; set; }
        public bool  Status { get; set; }=true;

    }
}
