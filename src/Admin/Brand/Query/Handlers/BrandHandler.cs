using BrandEntity = ecommerce.Domain.Entities.Brand;
using ecommerce.models.SuperAdmin.Brand.Commands;
using ecommerce.models.SuperAdmin.Brand.Query;
using ecommerce_shared.OperationResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Brand;
using ecommerce.Dto.Results.Admin.Brand;
using ecommerce_shared.Pagination;
using Repositories.Brand.Store;

namespace ecommerce.admin.Brand.Query.Handlers
{
    public class BrandHandler : OperationResult,
        IRequestHandler<GetAllBrandQuery, JsonResult>,
        IRequestHandler<GetBrandQuery, JsonResult>


    {

        public IBrandRepository BrandRepository;

        public BrandHandler(IBrandRepository BrandRepository)
        {


            this.BrandRepository = BrandRepository;
        }


        public async Task<JsonResult> Handle(GetAllBrandQuery request, CancellationToken cancellationToken)
        {

            PageList<AddBrandResponse> Brands = await BrandRepository.GetAll(request.OrderBy, request.pageNumber, request.pageSize);


            return Success(Brands, "this is all your brands");
        }

        public async Task<JsonResult> Handle(GetBrandQuery request, CancellationToken cancellationToken)
        {

            var Brand = BrandRepository.Get(request.Id);
            return Success(BrandQuery.ToBrandQueryResponse.Compile()(Brand), "this is your brand");

        }
    }
}
