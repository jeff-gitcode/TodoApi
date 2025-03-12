using MediatR;

namespace Application.Features.Todo.Commands
{
    public class DeleteTodoCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}