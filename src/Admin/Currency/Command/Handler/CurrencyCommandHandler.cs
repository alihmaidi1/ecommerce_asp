//using ecommerce.models.SuperAdmin.Currency;
//using ecommerce_shared.OperationResult;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using Repositories.Currency;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ecommerce.superadmin.Currency.Command.Handler
//{
//    public class CurrencyCommandHandler : OperationResult,
//        IRequestHandler<ToggleCurrencyCommand, JsonResult>
//    {

//        public ICurrencyRepository CurrencyRepository;
//        public CurrencyCommandHandler(ICurrencyRepository CurrencyRepository) { 
        

//            this.CurrencyRepository = CurrencyRepository;

//        } 

//        public async Task<JsonResult> Handle(ToggleCurrencyCommand request, CancellationToken cancellationToken)
//        {

//            var IsToggle = CurrencyRepository.Toggle(request.Id);
//            return Success(IsToggle,"the Currency Status Was Changed Successfully");
//        }
//    }
//}
