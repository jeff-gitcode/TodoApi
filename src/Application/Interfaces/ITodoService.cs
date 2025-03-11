using Domain.Entities;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItem>> GetAllTodosAsync();
        Task<TodoItem> GetTodoByIdAsync(int id);
        Task CreateTodoAsync(CreateTodoDto createTodoDto);
        Task UpdateTodoAsync(int id, UpdateTodoDto updateTodoDto);
        Task DeleteTodoAsync(int id);
    }
}