﻿using ecommerce.Domain.Entities.Category;
using ecommerce_shared.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Dto.Results.Admin.Category
{
    public class GetCategoryResponse
    {
        public CategoryId Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public bool Status { get; set; } = true;

        public int Rank { get; set; }

        public string? Meta_Title { get; set; }

        public string? Meta_Description { get; set; }

        public virtual List<ImageResponse> Images { get; set; }
        public List<GetCategoryResponse> Childs { get; set; }


    }
}
