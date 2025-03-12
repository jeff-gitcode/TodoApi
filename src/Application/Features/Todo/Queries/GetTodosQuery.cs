using FluentValidation;
using MediatR;

namespace Application.Features.Todo.Queries
{
    public class GetTodosQuery : IRequest<List<TodoItemDto>>
    {
    }

    public class GetTodosQueryValidator : AbstractValidator<GetTodosQuery>
    {
        public GetTodosQueryValidator()
        {
            // Add validation rules here if needed
        }
    }


    public class TodoItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}