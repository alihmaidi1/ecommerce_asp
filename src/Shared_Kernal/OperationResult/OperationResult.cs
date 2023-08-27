using ecommerce_shared.OperationResult.Enum;
using ecommerce_shared.OperationResult.MethodExtension;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace ecommerce_shared.OperationResult
{
    public class OperationResult
    {

        //public IStringLocalizer<SharedResource> _StringLocalizer;
        public OperationResult() {
        
        }    



        public JsonResult Deleted<T>() where T : class
        {
                
            int StatusCode = (int)System.Net.HttpStatusCode.OK;
            string Message = "Deleted Successfully";
            return this.ToJsonResult<T>(StatusCode:StatusCode,Message:Message);
        }

        public  JsonResult NotFound<T>(string Message="") where T : class
        {

            int StatusCode = (int)OperationResultTypes.NotExist;

            return this.ToJsonResult<T>(StatusCode: StatusCode, Message: Message);
        }

        public JsonResult Success<T>(T Data,string ResultMessage="") where T : class
        {
            int StatusCode = (int)System.Net.HttpStatusCode.OK;
            //string Message = _StringLocalizer[SharedResourceKeys.Operation_Success];
            string Message = ResultMessage;
            return this.ToJsonResult<T>(StatusCode, Data, Message);

        }

        public JsonResult Success(string ResultMessage = "")
        {
            int StatusCode = (int)System.Net.HttpStatusCode.OK;
            string Message = ResultMessage;
            return this.ToJsonResult<object>(StatusCode,Message:Message);

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
