using System.Net;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TodoApi.Common;

namespace TodoApi.WebApp
{
    /// <summary>
    /// 全局异常类
    /// </summary>
    public class GlobalExceptionAttribute : IExceptionFilter
    {
        private static readonly ILog log = LogManager.GetLogger(AppSetting.LogRepository.Name, "GlobalException");

        public void OnException(ExceptionContext context)
        {
            log.Error("服务器异常：" + context.Exception);

            var json = new ErrorResponse(context.Exception.Message) { DeveloperMessage = context.Exception };

            context.Result = new ApplicationErrorResult(json);
            context.ExceptionHandled = true;
        }
    }
    
    public class ApplicationErrorResult : ObjectResult
    {
        public ApplicationErrorResult(object value) : base(value)
        {
            StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }
    public class ErrorResponse
    {
        public ErrorResponse(string msg)
        {
            Message = msg;
        }
        public string Message { get; set; }
        public object DeveloperMessage { get; set; }
    }
}