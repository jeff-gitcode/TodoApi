using Domain.Entities;
using Application.DTOs;
using Application.Features.Todo.Queries;

namespace Application.Interfaces
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItemDto>> GetAllTodosAsync();
        Task<TodoItemDto?> GetTodoByIdAsync(int id);
        Task<TodoItemDto> CreateTodoAsync(TodoItemDto todoItemDto);
        Task UpdateTodoAsync(TodoItemDto todoItem);
        Task DeleteTodoAsync(int id);
    }
}