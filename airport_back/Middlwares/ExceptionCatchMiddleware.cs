using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace airport_back.Middlwares
{
    public class ExceptionCatchMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionCatchMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new ExceptionModel { Message = e.Message }));
            }
        }
    }

    public class ExceptionModel
    {
        public string Message { get; set; }
    }
}