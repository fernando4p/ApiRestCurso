using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ApiRestCurso.Extension
{
    public static class ApiExcetionMiddlewareExtension
    {

        public static  void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
             

                appError.Run(async context =>
                {

                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeacture = context.Features.Get<IExceptionHandlerFeature>();
                    if(context != null)
                    {
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            Statuscode = context.Response.StatusCode,
                            Message = contextFeacture.Error.Message,
                            Trace = contextFeacture.Error.StackTrace
                        }.ToString());
                    }

                });
            });
        }

    }
}
