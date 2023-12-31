﻿using CategoryEntity = ecommerce.Domain.Entities.Category.Category;
using ecommerce.Dto.Results.Admin.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ecommerce_shared.File;

namespace Repositories.Category.Operations
{
    public static class CategoryQuery
    {

        public static Expression<Func<CategoryEntity, AddCategoryResponse>> ToCategoryResponse = c => new AddCategoryResponse
        {

            Id = c.Id,
            Name = c.Name,
            Status = c.Status,
            Description = c.Description,
            Images = c.Images.Select(x => new ImageResponse { hash = x.Hash, resized = x.Resized, Url = x.Url }).ToList(),
            Meta_Description = c.Meta_Description,
            Meta_Title = c.Meta_Title,
            Rank = c.Rank,


        };

        public static Expression<Func<CategoryEntity, GetAllCategoryResponse>> ToAllCategoryResponse = c => new GetAllCategoryResponse
        {

            Id = c.Id,
            Name = c.Name,
            Status = c.Status,
            Description = c.Description,
            Images = c.Images.Select(x => new ImageResponse { hash = x.Hash, resized = x.Resized, Url = x.Url }).ToList(),
            Meta_Description = c.Meta_Description,
            Meta_Title = c.Meta_Title,
            Rank = c.Rank,



        };



        public static Expression<Func<CategoryEntity, GetCategoryWithParent>> ToAllCategoryWithParent = c => new GetCategoryWithParent
        {

            Id = c.Id,
            Name = c.Name,
            Status = c.Status,
            Description = c.Description,
            Images = c.Images.Select(x => new ImageResponse { hash = x.Hash, resized = x.Resized, Url = x.Url }).ToList(),
            Meta_Description = c.Meta_Description,
            Meta_Title = c.Meta_Title,
            Rank = c.Rank,
            ParentId = c.ParentId


        };

    }
}
