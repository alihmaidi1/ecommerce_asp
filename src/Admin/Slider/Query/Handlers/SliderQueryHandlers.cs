using ecommerce.models.SuperAdmin.Slider.Command;
using ecommerce.models.SuperAdmin.Slider.Query;
using ecommerce_shared.OperationResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Repositories.Slider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.superadmin.Slider.Query.Handlers
{
    public class SliderQueryHandlers : OperationResult,
        IRequestHandler<GetAllSliderQuery, JsonResult>,
        IRequestHandler<GetSliderQuery, JsonResult>


    {

        public ISliderRepository SliderRepository;


        public SliderQueryHandlers(ISliderRepository SliderRepository) { 
        

            this.SliderRepository = SliderRepository;
        
        }


        public async Task<JsonResult> Handle(GetAllSliderQuery request, CancellationToken cancellationToken)
        {
            var Sliders = SliderRepository.GetAll();


            return Success(Sliders,"this is all your sliders");

        }

        public async Task<JsonResult> Handle(GetSliderQuery request, CancellationToken cancellationToken)
        {

            var Slider = SliderRepository.Get(request.Id);
            return Success(Slider,"this is the slider");


        }
    }
}
