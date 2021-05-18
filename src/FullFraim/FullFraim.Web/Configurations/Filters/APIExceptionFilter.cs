using FullFraim.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Shared;
using System;

namespace FullFraim.Web.Filters
{
    public class APIExceptionFilter : Attribute, IExceptionFilter
    {
        private readonly ILogger<APIExceptionFilter> logger;

        public APIExceptionFilter(ILogger<APIExceptionFilter> logger)
        {
            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var source = context.Exception.Source;

            if (exception is NullModelException nullEx)
            {
                context.Result = new ContentResult()
                {
                    Content = nullEx.Message,
                    StatusCode = 400,
                };
            }
            else if (exception is DbModelNotFoundException notFoundEx)
            {
                context.Result = new ContentResult()
                {
                    Content = notFoundEx.Message,
                    StatusCode = 400,
                };

            }
            else if (exception is InvalidIdException invalidIdEx)
            {
                context.Result = new ContentResult()
                {
                    Content = invalidIdEx.Message,
                    StatusCode = 400,
                };
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
