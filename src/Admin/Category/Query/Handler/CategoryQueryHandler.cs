using ecommerce.Dto.Results.Admin.Category;
using ecommerce.models.SuperAdmin.Category.Command;
using ecommerce.models.SuperAdmin.Category.Query;
using ecommerce_shared.OperationResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Repositories.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.superadmin.Category.Query.Handler
{
    public class CategoryQueryHandler : OperationResult,
        IRequestHandler<GetAllCategory, JsonResult>,
        IRequestHandler<GetAllCategoryAsTreeQuery, JsonResult>,
        IRequestHandler<GetCategoryQuery, JsonResult>


    {

        public ICategoryRepository CategoryRepository { get; set; }
        public CategoryQueryHandler(ICategoryRepository CategoryRepository) {
        
            this.CategoryRepository = CategoryRepository;
        
        }

        public async Task<JsonResult> Handle(GetAllCategory request, CancellationToken cancellationToken)
        {
            
            var Categories = CategoryRepository.GetCategories(request.OrderBy,request.pageNumber,request.pageSize,request.status??true);
            return Success(Categories,"This Is All Categories");
            
        }
        public async Task<JsonResult> Handle(GetAllCategoryAsTreeQuery request, CancellationToken cancellationToken)
        {
            var Categories = CategoryRepository.GetCategoryTree();
            return Success(Categories, "this is all your categories");
        }

        public async Task<JsonResult> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            GetCategoryResponse Category = CategoryRepository.GetCategory(request.Id);


            return Success(Category, "This is the category");
        }
    }
}
