using Domain.Entities;

namespace Application.Interfaces
{
    public interface ITodoRepository
    {
        Task<TodoItem> GetTodoByIdAsync(int id);
        Task<IEnumerable<TodoItem>> GetAllTodosAsync();
        Task<TodoItem> AddTodoAsync(TodoItem todoItem);
        Task UpdateTodoAsync(TodoItem todoItem);
        Task DeleteTodoAsync(int id);
    }
}