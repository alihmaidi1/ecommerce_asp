using ecommerce_shared.Exceptions;
using ecommerce_shared.OperationResult.Base;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ecommerce_shared.Middleware
{
    public class ErrorHandling : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{

				await next(context);
            }
            catch (Exception error)
            {
            
                var response=context.Response;
                response.ContentType= "application/json";
                var Result = new OperationResultBase<string>() { };


                switch (error)
                {


                    case ValidationException exception:
                        Result.Message = exception.Message;
                        Result.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                        response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                        Result.Errors = exception.Errors.Select(f => f.PropertyName + ":" + f.ErrorMessage).ToList(); ;
                        break;

                    case UnAuthenticationException exception:
                        Result.Message = exception.Message;
                        Result.StatusCode = (int)HttpStatusCode.Unauthorized;
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        break;

                    case Exception exception:
                        Result.Message = exception.Message;
                        Result.StatusCode= (int)HttpStatusCode.InternalServerError;
                        response.StatusCode= (int)HttpStatusCode.InternalServerError;
                        break;

                }

                var errors= JsonSerializer.Serialize(Result);
                await response.WriteAsync(errors);

            }
        }
    }
}
