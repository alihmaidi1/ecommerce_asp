using ecommerce_shared.OperationResult.Base;
using ecommerce_shared.OperationResult.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.OperationResult
{
    public sealed class OperationResult<T>: OperationResultBase<T>
    {

        public static OperationResultBase<T> Deleted()
            {

                var StatusCode = (int?)System.Net.HttpStatusCode.OK;
                string Message = "Deleted Succcessfully";
                return new OperationResultBase<T>() { 
                
                    StatusCode = StatusCode,
                    Message = Message
                };

            }

        public static OperationResultBase<T> Success(T Data)
        {
            T Result = Data;
            var StatusCode = (int?)System.Net.HttpStatusCode.OK;
            string Message = "Added Successfully";
            return new OperationResultBase<T>()
            {

                StatusCode = StatusCode,
                Message = Message,
                Result = Result 
            };

        }


    }
}
