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

            var exMessage = context.Exception.Message;
            var source = context.Exception.Source;
            var stackTrace = context.Exception.StackTrace;

            if(exception is ArgumentNullException)
            {
                context.Result = new ContentResult() 
                { Content = Constants.Exceptions.ArgumentNull_Content, StatusCode = 400 };

            }
            /*else if(exception is Exception)
            {
                context.Result = new ContentResult()
                { Content = Constants.Exceptions.Server500_Content, StatusCode = 500 };
            }*/

            logger.LogError(exMessage, source);
        }
    }
}
