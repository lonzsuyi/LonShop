using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using LonShop.BaseCore.Interfaces;

namespace LonShop.LonShopWeb.Filters
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly IAppLogger<HttpGlobalExceptionFilter> _logger;

        public HttpGlobalExceptionFilter(IAppLogger<HttpGlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception.Message);
            context.Result = new StatusCodeResult(500);
        }
    }
}
