using Cinema.Domain.Exceptions;

namespace Cinema.Api.Middleware;

public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (NotFoundException notfoundException)
        {
            logger.LogWarning("{@notfoundException.Message}", notfoundException.Message);
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync(notfoundException.Message);
        }
        catch (ForbiddenException forbiddenException)
        {
            logger.LogWarning("{@forbiddenException.Message}", forbiddenException.Message);
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync(forbiddenException.Message);
        }
        catch (Exception ex)
        {
            logger.LogError("{@ex.Message}", ex.Message);
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync(ex.Message);
        }
    }
}