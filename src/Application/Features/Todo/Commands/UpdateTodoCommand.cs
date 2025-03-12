using MediatR;
using Application.DTOs;
using Application.Features.Todo.Queries;

namespace Application.Features.Todo.Commands
{
    public class UpdateTodoCommand : IRequest<TodoItemDto?>
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}