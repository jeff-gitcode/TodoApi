using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Application.Interfaces;

namespace TodoApi.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IJwtService jwtService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                var userPrincipal = jwtService.ValidateToken(token);
                if (userPrincipal != null)
                {
                    context.User = userPrincipal;
                }
            }

            await _next(context);
        }
    }
}