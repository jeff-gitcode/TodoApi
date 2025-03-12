using Application.Features.Todo.Queries;
using MediatR;

namespace Application.Features.Todo.Commands
{
    public class CreateTodoCommand : IRequest<TodoItemDto>
    {
        public string Title { get; set; } = string.Empty;
    }
}