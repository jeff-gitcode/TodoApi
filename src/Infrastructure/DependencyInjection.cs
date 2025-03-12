// src/Infrastructure/DependencyInjection.cs
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Application.Interfaces;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TodoDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ITodoRepository, TodoRepository>();
            // Configure JwtService with parameters from configuration
            var jwtSecret = configuration["Jwt:Key"];
            var jwtExpiryDuration = double.Parse(configuration["Jwt:ExpiryDuration"]);
            services.AddScoped<IJwtService>(provider => new JwtService(jwtSecret, jwtExpiryDuration));


            return services;
        }
    }
}