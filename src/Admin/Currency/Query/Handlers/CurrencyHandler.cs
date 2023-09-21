using ecommerce.admin.Country.Queries.Models;
using ecommerce.models.SuperAdmin.Currency;
using ecommerce_shared.OperationResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Repositories.Currency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.superadmin.Currency.Query.Handlers
{
    public class CurrencyHandler : OperationResult,
        IRequestHandler<GetAllCurrencyQuery, JsonResult>
    {

        public ICurrencyRepository CurrencyRepository;

        public CurrencyHandler(ICurrencyRepository CurrencyRepository)
        {

            this.CurrencyRepository = CurrencyRepository;   

        }

        public async Task<JsonResult> Handle(GetAllCurrencyQuery request, CancellationToken cancellationToken)
        {

            var Currencies = CurrencyRepository.GetAll();
            return Success(Currencies,"this is all your currencies");
        }
    }
}
