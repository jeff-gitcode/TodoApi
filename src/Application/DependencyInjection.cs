// src/Application/DependencyInjection.cs
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using FluentValidation;
using Application.Behaviors;
using Application.Features.Todo.Commands;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateTodoCommand).Assembly);
            services.AddValidatorsFromAssembly(typeof(CreateTodoCommand).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}