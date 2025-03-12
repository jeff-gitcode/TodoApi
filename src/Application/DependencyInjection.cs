// src/Application/DependencyInjection.cs
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using FluentValidation;
using Application.Behaviors;
using Application.Services;
using Application.Interfaces;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddScoped<ITodoService, TodoService>();

            return services;
        }
    }
}