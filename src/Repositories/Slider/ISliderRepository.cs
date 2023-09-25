using ecommerce.Domain.Entities.Slider;
using ecommerce.Dto.Results.Admin;
using Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SliderEntity = ecommerce.Domain.Entities.Slider.Slider;

namespace Repositories.Slider
{
    public interface ISliderRepository : IgenericRepository<SliderEntity>
    {

        public Task<SliderEntity> Store(string url, int rank);

        public List<AddSliderResponse> GetAll();

        public bool IsExists(SliderId Id);

        public AddSliderResponse Get(SliderId id);

        public bool IsUniqueRank(SliderId Id, int Rank);

        public bool IsValidLogo(SliderId Id, string logo);

        public Task<AddSliderResponse> Update(SliderId id, string url, int rank);


        public bool Delete(SliderId id);

    }
}
