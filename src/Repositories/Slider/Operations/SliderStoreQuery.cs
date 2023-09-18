using SliderEntity=ecommerce.Domain.Entities.Slider;
using ecommerce.Dto.Results.Admin.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ecommerce.Dto.Results.Admin;

namespace Repositories.Slider.Operations
{
    public static class SliderStoreQuery
    {

        public static Expression<Func<SliderEntity, AddSliderResponse>> ToSliderResponse = b => new AddSliderResponse()
        {

            Id = b.Id,   
            Rank=b.Rank,
            image = new ecommerce_shared.File.ImageResponse()
            {

                hash = b.Hash,
                resized = b.ResizedUrl,
                Url = b.Url

            }

        };



    }
}
