using CurrencyEntity=ecommerce.Domain.Entities.Currency;
using Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerce.Dto.Results.Admin.Currency;

namespace Repositories.Currency
{
    public interface ICurrencyRepository:IgenericRepository<CurrencyEntity>
    {


        public List<GetCurrencyResponse> GetAll();

        public bool IsExists(Guid Id);
        public bool Toggle(Guid Id);


    }
}
