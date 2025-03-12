// src/Domain/DependencyInjection.cs
using Microsoft.Extensions.DependencyInjection;

namespace Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            // Add domain services here if any

            return services;
        }
    }
}