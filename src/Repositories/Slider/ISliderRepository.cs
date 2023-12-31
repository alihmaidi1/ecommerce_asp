﻿using ecommerce.Domain.Entities.Slider;
using ecommerce.Dto.Results.Admin;
using Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
using SliderEntity = ecommerce.Domain.Entities.Slider.Slider;
=======
using ecommerce_shared.Pagination;
using SliderEntity=ecommerce.Domain.Entities.Slider;
>>>>>>> ed

namespace Repositories.Slider
{
    public interface ISliderRepository : IgenericRepository<SliderEntity>
    {

        public Task<SliderEntity> Store(string url, int rank);

        public PageList<AddSliderResponse> GetAll(int? PageNumber,int? PageSize);

        public bool IsExists(SliderId Id);

        public AddSliderResponse Get(SliderId id);

        public bool IsUniqueRank(SliderId Id, int Rank);

        public bool IsValidLogo(SliderId Id, string logo);

        public Task<AddSliderResponse> Update(SliderId id, string url, int rank);


        public bool Delete(SliderId id);

    }
}
