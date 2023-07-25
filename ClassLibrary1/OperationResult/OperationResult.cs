using ecommerce_shared.OperationResult.Base;
using ecommerce_shared.OperationResult.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.OperationResult
{
    public sealed class OperationResult<T>: Base.OperationResultBase<T>
    {

        public static Base.OperationResultBase<T> Deleted()
            {

                var StatusCode = (int?)System.Net.HttpStatusCode.OK;
                string Message = "Deleted Succcessfully";
                return new Base.OperationResultBase<T>() { 
                
                    StatusCode = StatusCode,
                    Message = Message
                };

            }

        public static Base.OperationResultBase<T> NotFound(string message="")
        {

            return new Base.OperationResultBase<T>()
            {
                StatusCode=(int)OperationResultTypes.NotExist,
                Message= message,

            };
        }

        public static Base.OperationResultBase<T> Success(T Data)
        {
            T Result = Data;
            var StatusCode = (int?)System.Net.HttpStatusCode.OK;
            string Message = "Added Successfully";
            return new Base.OperationResultBase<T>()
            {

                StatusCode = StatusCode,
                Message = Message,
                Result = Result 
            };

        }
        public Base.OperationResultBase<T> Created(string message="")
        {

            var StatusCode = (int?)System.Net.HttpStatusCode.Created;
            string Message = message;
            return new Base.OperationResultBase<T>()
            {

                StatusCode = StatusCode,
                Message = Message
            };


        }
        public static Base.OperationResultBase<T> Exists(string message="")
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
