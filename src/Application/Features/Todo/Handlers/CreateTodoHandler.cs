using MediatR;
using Application.Interfaces;
using Application.DTOs;
using Application.Features.Todo.Commands;

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
            var todoItem = new CreateTodoDto
            {
                Title = request.Title
            };

            var createdTodo = await _todoService.CreateTodoAsync(todoItem);
            return new TodoItemDto
            {
                Id = createdTodo.Id,
                Title = createdTodo.Title
            };
        }
    }
}