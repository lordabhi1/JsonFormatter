﻿using ExceptionHandling.Domain.DomainException;

namespace JsonFormatterProject
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }catch(NotFoundException ex) 
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(ex.Message);
            }
            catch(Exception ex) 
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync($"{ex.Message}"); 
            }
        }
    }
}
