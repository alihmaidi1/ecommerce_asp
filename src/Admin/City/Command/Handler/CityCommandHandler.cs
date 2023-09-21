using ecommerce.models.SuperAdmin.Category.Command;
using ecommerce.models.SuperAdmin.City.Command;
using ecommerce_shared.OperationResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Repositories.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.superadmin.City.Command.Handler
{
    public class CityCommandHandler : OperationResult,
        IRequestHandler<ToggleCityCommand, JsonResult>
    {

        public ICityRepository CityRepository;
        public CityCommandHandler(ICityRepository CityRepository) { 
        

            this.CityRepository = CityRepository;

        
        }
        public async Task<JsonResult> Handle(ToggleCityCommand request, CancellationToken cancellationToken)
        {

            var IsToggle = CityRepository.Toggle(request.Id);
            return Success(IsToggle,"the city status was changed successfully");
        }
    }
}
