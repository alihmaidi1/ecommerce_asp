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
        IRequestHandler<GetAllCategory, JsonResult>
    {

        public ICategoryRepository CategoryRepository { get; set; }
        public CategoryQueryHandler(ICategoryRepository CategoryRepository) {
        
            this.CategoryRepository = CategoryRepository;
        
        }

        public async Task<JsonResult> Handle(GetAllCategory request, CancellationToken cancellationToken)
        {

            var Categories = CategoryRepository.GetCategories();
            return Success(Categories,"This Is All Categories");
        }
    }
}
