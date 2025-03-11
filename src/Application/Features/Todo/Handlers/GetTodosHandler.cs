using MediatR;
using Application.Interfaces;
using Application.Features.Todo.Queries;

namespace Application.Features.Todo.Handlers
{
    public class GetTodosHandler : IRequestHandler<GetTodosQuery, List<TodoItemDto>>
    {
        private readonly ITodoService _todoService;

        public GetTodosHandler(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public async Task<List<TodoItemDto>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
        {
            var todos = await _todoService.GetAllTodosAsync();
            return todos.Select(todo => new TodoItemDto
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                Status = "Completed"
            }).ToList();
        }
    }
}