using ecommerce.Domain.SharedResources;
using ecommerce_shared.OperationResult.Base;
using ecommerce_shared.OperationResult.Enum;
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
        public Base.OperationResultBase<T> Deleted<T>()
            {
                
                var StatusCode = (int?)System.Net.HttpStatusCode.OK;
                string Message = _StringLocalizer[SharedResourceKeys.Deleted];
                
            return new Base.OperationResultBase<T>() { 
                
                    StatusCode = StatusCode,
                    Message = Message
                };

            }

        public  Base.OperationResultBase<T> NotFound<T>(string message="")
        {
             
            return new Base.OperationResultBase<T>()
            {
                StatusCode=(int)OperationResultTypes.NotExist,
                Message= message,

            };
        }

        public Base.OperationResultBase<T> Success<T>(T Data)
        {
            T Result = Data;
            var StatusCode = (int?)System.Net.HttpStatusCode.OK;
            string Message = _StringLocalizer[SharedResourceKeys.Operation_Success];
            return new Base.OperationResultBase<T>()
            {

                StatusCode = StatusCode,
                Message = Message,
                Result = Result 
            };

        }
        public Base.OperationResultBase<T> Created<T>(T data,string message = "")
        {

            var StatusCode = (int?)System.Net.HttpStatusCode.Created;
            string Message = message;
            return new Base.OperationResultBase<T>()
            {

                StatusCode = StatusCode,
                Message = Message,
                Result= data
            };


        }
            public  Base.OperationResultBase<T> Exists<T>(string message="")
          {
            var StatusCode = (int?)System.Net.HttpStatusCode.UnprocessableEntity;
            string Message = message;
            return new Base.OperationResultBase<T>()
            {

                StatusCode = StatusCode,
                Message = Message
            };

        }

    }
}
