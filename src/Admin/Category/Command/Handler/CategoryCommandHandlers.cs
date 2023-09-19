using ecommerce.models.SuperAdmin.Brand.Commands;
using ecommerce.models.SuperAdmin.Category.Command;
using ecommerce_shared.OperationResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Repositories.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.superadmin.Category.Command.Handler
{
    public class CategoryCommandHandlers : OperationResult,
        IRequestHandler<StoreCategoryCommand, JsonResult>
    {
        public ICategoryRepository CategoryRepository;
        public CategoryCommandHandlers(ICategoryRepository CategoryRepository) { 
        
            this.CategoryRepository = CategoryRepository;   
        }
        public async Task<JsonResult> Handle(StoreCategoryCommand request, CancellationToken cancellationToken)
        {

            var Category = await CategoryRepository.Store(request.Name,request.Description
                ,request.Meta_Title,request.Rank,request.Meta_Description
                ,request.ParentId,request.Tags,request.Images);
            return Success(Category, "the category was added successfully");
        }
    }
}
