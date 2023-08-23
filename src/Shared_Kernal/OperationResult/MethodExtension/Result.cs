using ecommerce_shared.OperationResult.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.OperationResult.MethodExtension
{
    public static class Result
    {


        public static OperationResultBase<T> CreateOperationResultBase<T>(T Result,string Message,int StatusCode) where T:class
        {

            return new OperationResultBase<T>
            {
                Result=Result,
                Message=Message,
                StatusCode=StatusCode

            };

        }
        public static JsonResult ToJsonResult<T>(this OperationResult OperationResult, int StatusCode, T? Result=null,string Message="") where T:class
        {

            var OperationResultBase=CreateOperationResultBase<T>(Result,Message,StatusCode);
            return new JsonResult(OperationResultBase)
            {

                StatusCode=StatusCode
            };
        
        }

        public static async Task<JsonResult> ToJsonResultAsync<T>(this Task<OperationResult> OperationResult, int StatusCode, T? Result = null, string Message = "") where T : class
        {

            return (await OperationResult).ToJsonResult(StatusCode,Result,Message);
        }
    }
}
