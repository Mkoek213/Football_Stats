using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;


public class ApiKeyAuthMiddleware
{
    private readonly RequestDelegate _next;

    public ApiKeyAuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, FootballLeagueContext db)
    {
        if (context.Request.Path.StartsWithSegments("/api"))
        {
            var username = context.Request.Headers["X-Username"].ToString();
            var apiKey = context.Request.Headers["X-Api-Key"].ToString();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(apiKey))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Brak danych uwierzytelniających");
                return;
            }

            var user = db.Users.FirstOrDefault(u => u.Username == username && u.ApiKey == apiKey);
            if (user == null)
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Niepoprawne dane uwierzytelniające");
                return;
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var identity = new ClaimsIdentity(claims, "ApiKey");
            context.User = new ClaimsPrincipal(identity);
        }

        await _next(context);
    }
}
