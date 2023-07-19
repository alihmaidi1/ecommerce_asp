using ecommerce.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;

namespace tables.Entities
{
    internal class Banner :BaseEntity
    {
        public string Url   { get; set; }
        public string Link { get; set; }   
        public bool Status  { get; set; }
        public int Rank { get; set; }   
        public BannerShow showIn  { get; set; }

    }
}
