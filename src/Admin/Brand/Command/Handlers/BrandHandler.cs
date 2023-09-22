//using BrandEntity = ecommerce.Domain.Entities.Brand.Brand;
//using ecommerce.models.SuperAdmin.Brand.Commands;
//using ecommerce.service.BrandService;
//using ecommerce_shared.OperationResult;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using ecommerce.Dto.Results.Admin.Brand;
//using Repositories.Brand;
//using Repositories.Brand.Store;

//namespace ecommerce.admin.Brand.Command.Handlers
//{
//    public class BrandHandler : OperationResult,
//        IRequestHandler<AddBrandCommand, JsonResult>,
//        IRequestHandler<UpdateBrandCommand, JsonResult>,
//        IRequestHandler<DeletebrandCommand, JsonResult>



//    {
//        public IBrandRepository BrandRepository;
//        public IBrandService BrandService;
//        public BrandHandler(IBrandService BrandService, IBrandRepository BrandRepository)
//        {


//            this.BrandRepository = BrandRepository;
//            this.BrandService = BrandService;
//        }


//        public async Task<JsonResult> Handle(AddBrandCommand request, CancellationToken cancellationToken)
//        {

//            AddBrandResponse Brand = await BrandService.CreateBrand(request);
//            return Success(Brand, "The Brand Was Created Successfully");
//        }

//        public async Task<JsonResult> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
//        {

//            BrandEntity brand = await BrandRepository.Update(request);

//            return Success(BrandQuery.ToBrandResponse.Compile()(brand), "the brand was updated successfully");
//        }

//        public async Task<JsonResult> Handle(DeletebrandCommand request, CancellationToken cancellationToken)
//        {

//            return Success(BrandRepository.Delete(request.Id), "the brand was deleted successfully");

//        }
//    }
//}
