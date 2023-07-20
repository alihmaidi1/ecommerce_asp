using ecommerce.Domain.Base.Entity;
using ecommerce.Domain.Base.Interfaces;
using ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;

namespace tables.Entities
{
    public class Slider :Imagable
    {
        public Image Url { get; set; }
        public string Rank { get; set; }
        public bool  Status { get; set; }=true;

    }
}
