using MediatR;
using Application.DTOs;
using FluentValidation;

namespace Application.Features.Todo.Queries
{
    public class GetTodoByIdQuery : IRequest<TodoItemDto>
    {
        public int Id { get; set; }
    }

}