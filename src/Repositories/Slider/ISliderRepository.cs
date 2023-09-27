using ecommerce.Dto.Results.Admin;
using Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerce_shared.Pagination;
using SliderEntity=ecommerce.Domain.Entities.Slider;

namespace Repositories.Slider
{
    public interface ISliderRepository:IgenericRepository<SliderEntity>
    {

        public Task<SliderEntity> Store(string url,int rank);

        public PageList<AddSliderResponse> GetAll(int? PageNumber,int? PageSize);

        public bool IsExists(Guid Id);

        public AddSliderResponse Get(Guid id);

        public bool IsUniqueRank(Guid Id,int Rank);

        public bool IsValidLogo(Guid Id, string logo);

        public Task<AddSliderResponse> Update(Guid id, string url, int rank);


        public bool Delete(Guid id);

    }
}
