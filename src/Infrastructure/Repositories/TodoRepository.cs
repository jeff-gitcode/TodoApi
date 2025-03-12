using Domain.Entities;
using Infrastructure.Persistence;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext _context;

        public TodoRepository(TodoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoItem>> GetAllTodosAsync()
        {
            // Return all TodoItems from the database if null return empty list
            return _context.TodoItems != null ? await _context.TodoItems.ToListAsync() : new List<TodoItem>();
        }

        public async Task<TodoItem> GetTodoByIdAsync(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                throw new KeyNotFoundException($"TodoItem with id {id} not found.");
            }
            return todoItem;
        }

        public async Task<int> AddTodoAsync(TodoItem todoItem)
        {
            await _context.TodoItems.AddAsync(todoItem);
            await _context.SaveChangesAsync();
            return todoItem.Id;
        }

        public async Task UpdateTodoAsync(TodoItem todoItem)
        {
            _context.TodoItems.Update(todoItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTodoAsync(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem != null)
            {
                _context.TodoItems.Remove(todoItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}