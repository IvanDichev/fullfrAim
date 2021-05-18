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

            if(exception is ArgumentNullException ex)
            {
                context.Result = new ContentResult()
                {
                    Content = ex.Message,
                    StatusCode = 500,
                };

                logger.LogError(ex.Message, source);
            }

            logger.LogCritical(Constants.Exceptions.APIFilterFail_Critical, source);
        }
    }
}
