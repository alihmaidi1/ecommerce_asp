using ecommerce.models.SuperAdmin.Role.Query;
using ecommerce.models.SuperAdmin.Slider.Command;
using ecommerce_shared.OperationResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Repositories.Slider;
using Repositories.Slider.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.superadmin.Slider.Command.Handlers
{
    public class SliderCommandHandlers : OperationResult,
        IRequestHandler<StoreSliderCommand, JsonResult>,
        IRequestHandler<UpdateSliderCommand, JsonResult>,
        IRequestHandler<DeleteSliderCommand, JsonResult>


    {

        public ISliderRepository SliderRepository;

        public SliderCommandHandlers(ISliderRepository SliderRepository)
        {


            this.SliderRepository = SliderRepository;
        }

        public async Task<JsonResult> Handle(StoreSliderCommand request, CancellationToken cancellationToken)
        {


            var Slider = await SliderRepository.Store(request.Url, request.Rank);
            return Success(SliderStoreQuery.ToSliderResponse.Compile()(Slider), "the slider was created successfully");

        }

        public async Task<JsonResult> Handle(UpdateSliderCommand request, CancellationToken cancellationToken)
        {
            var Slider = await SliderRepository.Update(request.Id, request.url, request.Rank);
            return Success(Slider, "The Slider Was Updated Successfully");
        }

        public async Task<JsonResult> Handle(DeleteSliderCommand request, CancellationToken cancellationToken)
        {

            SliderRepository.Delete(request.Id);

            return Success(true, "the Slider Was Deleted Successfully");


        }
    }
}
