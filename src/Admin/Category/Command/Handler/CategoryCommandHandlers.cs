//using ecommerce.models.SuperAdmin.Brand.Commands;
//using ecommerce.models.SuperAdmin.Category.Command;
//using ecommerce_shared.OperationResult;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using Repositories.Category;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ecommerce.superadmin.Category.Command.Handler
//{
//    public class CategoryCommandHandlers : OperationResult,
//        IRequestHandler<StoreCategoryCommand, JsonResult>,
//        IRequestHandler<UpdateCategoryCommand, JsonResult>,
//        IRequestHandler<UnActiveCategoryCommand, JsonResult>,
//        IRequestHandler<ActiveCategoryCommand, JsonResult>,
//        IRequestHandler<DeleteCategoryCommand, JsonResult>




//    {
//        public ICategoryRepository CategoryRepository;
//        public CategoryCommandHandlers(ICategoryRepository CategoryRepository) { 
        
//            this.CategoryRepository = CategoryRepository;   
//        }
//        public async Task<JsonResult> Handle(StoreCategoryCommand request, CancellationToken cancellationToken)
//        {

//            var Category = await CategoryRepository.Store(request.Name,request.Description
//                ,request.Meta_Title,request.Rank,request.Meta_Description
//                ,request.ParentId,request.Images);
//            return Success(Category, "the category was added successfully");
//        }

//        public async Task<JsonResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
//        {

//            var Category = await CategoryRepository.Update(request.Id, request.Name,
//                request.Description, request.Meta_Title, request.Rank,
//                request.Meta_Description, request.ParentId, 
//                request.Images, request.DeletedImages);
//            return Success(Category, "the category was updated successfully");

//        }

//        public async Task<JsonResult> Handle(UnActiveCategoryCommand request, CancellationToken cancellationToken)
//        {

//            bool isUnActivated=CategoryRepository.UnActive(request.Id);
//            return Success(isUnActivated, "the category was unactivated successfully");
//        }

//        public async Task<JsonResult> Handle(ActiveCategoryCommand request, CancellationToken cancellationToken)
//        {

//            bool IsActivated=CategoryRepository.ActiveCategory(request.Id);

//            return Success(IsActivated, "the category was activated successfully");

//        }

//        public async Task<JsonResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
//        {

//            bool isDeleted = CategoryRepository.Delete(request.Id);

//            return Success(isDeleted, "the category was deleted successfully");

//        }
//    }
//}
