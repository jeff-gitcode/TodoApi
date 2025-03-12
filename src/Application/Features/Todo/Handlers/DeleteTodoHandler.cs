using MediatR;
using Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.Todo.Commands;

namespace Application.Features.Todo.Handlers
{
    public class DeleteTodoHandler : IRequestHandler<DeleteTodoCommand, bool>
    {
        private readonly ITodoService _todoService;

        public DeleteTodoHandler(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public async Task<bool> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = await _todoService.GetTodoByIdAsync(request.Id);
            if (todo == null)
            {
                return false;
            }

            await _todoService.DeleteTodoAsync(todo.Id);
            return true;
        }
    }
}