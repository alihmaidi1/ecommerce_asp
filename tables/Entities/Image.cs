using ecommerce.Domain.Base.Interfaces;
using ecommerce.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;

namespace ecommerce.Domain.Entities;

public class Image:BaseEntity
    {

        public string Url { get; set; }
        public string Hash { get; set; }

        public string ResizedUrl { get; set; }

        public EntitiesHasImages Type { get; set; }
        public IImage Imageable { get; set; }
        public Guid Imagable_id { get; set; }



}

