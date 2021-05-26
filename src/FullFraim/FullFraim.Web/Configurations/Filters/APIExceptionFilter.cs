﻿using FullFraim.Services.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shared;
using System;

namespace FullFraim.Web.Filters
{
    public class APIExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var logger = context.HttpContext.RequestServices
                .GetRequiredService<ILogger<APIExceptionFilter>>();

            var exception = context.Exception;
            var source = context.Exception.Source;

            if (exception is NullModelException nullEx)
            {
                context.Result = new ContentResult()
                {
                    Content = nullEx.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
            else if (exception is NotFoundException notFoundEx)
            {
                context.Result = new ContentResult()
                {
                    Content = notFoundEx.Message,
                    StatusCode = StatusCodes.Status404NotFound,
                };
            }
            else if (exception is InvalidIdException invalidIdEx)
            {
                context.Result = new ContentResult()
                {
                    Content = invalidIdEx.Message,
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
            else if (exception is Exception ex)
            {
                context.Result = new ContentResult()
                {
                    Content = "Server unavailable",
                    StatusCode = StatusCodes.Status500InternalServerError,
                };

                logger.LogCritical(ex.Message, source);
            }
            else
            {
                logger.LogCritical(Constants.Exceptions.APIFilterFail_Critical, source);
                return;
            }

            logger.LogError(exception.Message, source);
        }
    }
}
