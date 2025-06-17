using MakimaFC.Extensions.WebApi.ProblemHandling.Exception;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MakimaFC.Extensions.WebApi.ProblemHandling;

public class MfcExceptionFilter : IAsyncExceptionFilter
{
    public async Task OnExceptionAsync(ExceptionContext context)
    {
        if (context.Exception is MfcException mfcException)
        {
            context.HttpContext.Response.StatusCode = (int)mfcException.StatusCode;
            context.HttpContext.Response.ContentType = "application/json";
            await context.HttpContext.Response.WriteAsync(mfcException.Message);
            context.ExceptionHandled = true;
        }
    }
}