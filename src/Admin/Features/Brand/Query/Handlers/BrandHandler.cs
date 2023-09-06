using BrandEntity=ecommerce.Domain.Entities.Brand;
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

namespace ecommerce.admin.Features.Brand.Query.Handlers
{
    public class BrandHandler : OperationResult,
        IRequestHandler<GetAllBrandQuery, JsonResult>

    {

        public IBrandRepository BrandRepository;

        public BrandHandler(IBrandRepository BrandRepository) {
        

            this.BrandRepository = BrandRepository;
        }


        public async Task<JsonResult> Handle(GetAllBrandQuery request, CancellationToken cancellationToken)
        {

            List<AddBrandResponse> Brands = BrandRepository.GetAll();
            //

            return Success(Brands,"this is all your brands");
        }
    }
}
