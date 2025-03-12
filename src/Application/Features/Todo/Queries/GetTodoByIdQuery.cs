using MediatR;
using Application.DTOs;

namespace Application.Features.Todo.Queries
{
    public class GetTodoByIdQuery : IRequest<TodoItemDto>
    {
        public int Id { get; set; }
    }
}