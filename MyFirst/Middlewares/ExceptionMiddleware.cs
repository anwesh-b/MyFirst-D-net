using System.Net;
using MyFirst.Exceptions;
using MyFirst.Model;
using JsonConvert = Newtonsoft.Json.JsonConvert; // Multiple packages exposing same API

namespace MyFirst.Middlewares;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (DataNotFoundException ex)
        {
            logger.LogError($"Something went wrong: {ex}");
            await HandleExceptionAsync(httpContext, ex.Message, (int)HttpStatusCode.NotFound);
        }
        catch (BadRequestException ex)
        {
            logger.LogError($"Something went wrong: source: {ex.Source} message: {ex.Message} data: {ex.Data}");
            await HandleExceptionAsync(httpContext, ex.Message, (int)HttpStatusCode.BadRequest);
        }
        catch (Exception ex)
        {
            logger.LogError($"Something went wrong: {ex}");
            await HandleExceptionAsync(httpContext, "Internal server error.", (int)HttpStatusCode.InternalServerError);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, string exceptionMessage, int code)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = code;

        var response = new ErrorResponseHandler()
        {
            StatusCode = code,
            Message = exceptionMessage
        };

        var final = JsonConvert.SerializeObject(response);
        
        await context.Response.WriteAsync(final);
    }
}
