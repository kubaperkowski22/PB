/* wariant 1
 * 
 * using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

public class CustomMiddleware
{
    private readonly RequestDelegate _next;

    public CustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var userAgent = context.Request.Headers["User-Agent"].ToString();
        await context.Response.WriteAsync($"User-Agent: {userAgent}");
        await _next(context);
    }
}

public static class CustomMiddlewareExtensions
{
    public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomMiddleware>();
    }
}*/


// wariant 2

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using UAParser;

< ItemGroup >
  < PackageReference Include = "UAParser" Version = "3.0.0" />
</ ItemGroup >

public class CustomMiddleware
{
    private readonly RequestDelegate _next;

    public CustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var userAgent = context.Request.Headers[HeaderNames.UserAgent].ToString();

        var parser = Parser.GetDefault();
        var clientInfo = parser.Parse(userAgent);

        if (clientInfo.UserAgent.Family.Equals("Edge", StringComparison.OrdinalIgnoreCase) ||
            clientInfo.UserAgent.Family.Equals("EdgeChromium", StringComparison.OrdinalIgnoreCase) ||
            clientInfo.UserAgent.Family.Equals("IE", StringComparison.OrdinalIgnoreCase))
        {
            context.Response.Redirect("https://www.mozilla.org/pl/firefox/new/");
            return;
        }

        await _next(context);
    }
}

public static class CustomMiddlewareExtensions
{
    public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomMiddleware>();
    }
}

public static class CustomMiddlewareServiceExtensions
{
    public static IServiceCollection AddCustomMiddleware(this IServiceCollection services)
    {
        return services.AddTransient<CustomMiddleware>();
    }
}
