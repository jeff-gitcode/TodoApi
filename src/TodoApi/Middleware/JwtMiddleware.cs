using Application.Interfaces;

namespace TodoApi.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IJwtService _jwtService;

        public JwtMiddleware(RequestDelegate next, IJwtService jwtService)
        {
            _next = next;
            _jwtService = jwtService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                var userPrincipal = _jwtService.ValidateToken(token);
                if (userPrincipal != null)
                {
                    context.User = userPrincipal;
                }
            }

            await _next(context);
        }
    }
}