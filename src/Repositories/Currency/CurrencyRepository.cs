using CurrencyEntity=ecommerce.Domain.Entities.Currency;
using Repositories.Base.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerce.infrutructure;
using ecommerce.Dto.Results.Admin.Currency;
using Repositories.Currency.Operation;
using ecommerce.infrutructure.ExtensionMethod;

namespace Repositories.Currency
{
    public class CurrencyRepository : GenericRepository<CurrencyEntity>, ICurrencyRepository
    {
        public CurrencyRepository(ApplicationDbContext DbContext) : base(DbContext)
        {
        }

        public List<GetCurrencyResponse> GetAll()
        {


            return DbContext.Currencies.Select(CurrencyQuery.ToCurrencyResponse).ToList();

        }


        public bool IsExists(Guid Id)
        {


            return DbContext.Currencies.Any(c => c.Id == Id);

        }


        public bool Toggle(Guid Id)
        {

            DbContext.Toggle("Currencies", "Status", Id);
            return true;

        }


    }
}
