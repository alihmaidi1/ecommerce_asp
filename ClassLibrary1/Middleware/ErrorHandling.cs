using Azure;
using ecommerce_shared.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
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
			catch (Exception e)
			{
				var Response = context.Response;

				switch (e)
				{

					case ValidationException:

						Response.StatusCode = 429;
					break;


                    case NotFoundException:


                        Response.StatusCode = 405;
                        await Response.WriteAsJsonAsync(e.Message);

                     break;


                    case ExistsException:


                        Response.StatusCode = 405;
                        await Response.WriteAsJsonAsync(e.Message);

                        break;
                    default:

						Response.StatusCode = 500;
						await Response.WriteAsJsonAsync(e.Message);
					break;

                }

			}
        }
    }
}
