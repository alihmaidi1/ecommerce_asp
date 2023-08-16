using ecommerce.Domain.SharedResources;
using ecommerce_shared.OperationResult.Base;
using ecommerce_shared.OperationResult.Enum;
using ecommerce_shared.OperationResult.MethodExtension;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.OperationResult
{
    public class OperationResult
    {

        public IStringLocalizer<SharedResource> _StringLocalizer;
        public OperationResult(IStringLocalizer<SharedResource> stringLocalizer) {
        
            _StringLocalizer = stringLocalizer;
        }    



        public JsonResult Deleted<T>() where T : class
        {
                
            int StatusCode = (int)System.Net.HttpStatusCode.OK;
            string Message = _StringLocalizer[SharedResourceKeys.Deleted];
            return this.ToJsonResult<T>(StatusCode:StatusCode,Message:Message);
        }

        public  JsonResult NotFound<T>(string Message="") where T : class
        {

            int StatusCode = (int)OperationResultTypes.NotExist;

            return this.ToJsonResult<T>(StatusCode: StatusCode, Message: Message);
        }

        public JsonResult Success<T>(T Data) where T : class
        {
            int StatusCode = (int)System.Net.HttpStatusCode.OK;
            string Message = _StringLocalizer[SharedResourceKeys.Operation_Success];

            return this.ToJsonResult<T>(StatusCode, Data, Message);

        }
        public JsonResult Created<T>(T Data, string Message = "") where T : class
        {

            int StatusCode = (int)System.Net.HttpStatusCode.Created;
            return this.ToJsonResult<T>(StatusCode,Data,Message);            


        }
            public  JsonResult Exists<T>(string Message="") where T : class
          {
            int StatusCode = (int)System.Net.HttpStatusCode.UnprocessableEntity;
            return this.ToJsonResult<T>(StatusCode,Message:Message);

        }

    }
}
