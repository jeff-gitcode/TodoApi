using MediatR;
using Application.Interfaces;
using Application.DTOs;
using Application.Features.Todo.Commands;
using Application.Features.Todo.Queries;

namespace Application.Features.Todo.Handlers
{
    public class CreateTodoHandler : IRequestHandler<CreateTodoCommand, TodoItemDto>
    {
        private readonly ITodoService _todoService;

        public CreateTodoHandler(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public async Task<TodoItemDto> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var todoItem = new TodoItemDto
            {
                Title = request.Title
            };

            return await _todoService.CreateTodoAsync(todoItem);
        }
    }
}