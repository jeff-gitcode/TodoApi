using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.DTOs;
using Application.Features.Todo.Queries;

namespace Application.Features.Todo.Handlers
{
    public class GetTodoByIdHandler : IRequestHandler<GetTodoByIdQuery, TodoItemDto>
    {
        private readonly ITodoService _todoService;

        public GetTodoByIdHandler(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public async Task<TodoItemDto?> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
        {
            var todo = await _todoService.GetTodoByIdAsync(request.Id);
            if (todo == null)
            {
                return null;
            }

            return new TodoItemDto
            {
                Id = todo.Id,
                Title = todo.Title
            };
        }
    }
}