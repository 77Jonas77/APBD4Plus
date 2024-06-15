using Microsoft.AspNetCore.Diagnostics;

namespace Cw11.Extentions;

public static class ExceptionMiddlewareExtention
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder appBuilder)
    {
        appBuilder.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    await File.AppendAllTextAsync("./logs.txt", contextFeature.Error + "\n");

                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsync("Error");
                }
            });
        });
    }
}