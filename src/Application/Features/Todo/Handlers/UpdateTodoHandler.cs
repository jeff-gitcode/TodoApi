using MediatR;
using Application.DTOs;
using Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.Todo.Commands;
using Application.Features.Todo.Queries;

namespace Application.Features.Todo.Handlers
{
    public class UpdateTodoHandler : IRequestHandler<UpdateTodoCommand, TodoItemDto?>
    {
        private readonly ITodoService _todoService;

        public UpdateTodoHandler(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public async Task<TodoItemDto?> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = await _todoService.GetTodoByIdAsync(request.Id);
            if (todo == null)
            {
                return null;
            }

            todo.Title = request.Title;

            var updateTodoDto = new TodoItemDto
            {
                Id = todo.Id,
                Title = todo.Title
            };

            await _todoService.UpdateTodoAsync(updateTodoDto);

            return new TodoItemDto
            {
                Id = todo.Id,
                Title = todo.Title,
            };
        }
    }
}