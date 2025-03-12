using Application.Interfaces;
using Domain.Entities;
using Application.DTOs;

namespace Application.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<IEnumerable<TodoItem>> GetAllTodosAsync()
        {
            return await _todoRepository.GetAllTodosAsync();
        }

        public async Task<TodoItem> GetTodoByIdAsync(int id)
        {
            return await _todoRepository.GetTodoByIdAsync(id);
        }

        public async Task<TodoItem> CreateTodoAsync(CreateTodoDto createTodoDto)
        {
            var todoItem = new TodoItem
            {
                Title = createTodoDto.Title
            };

            var id = await _todoRepository.AddTodoAsync(todoItem);

            todoItem.Id = id;
            return todoItem;
        }

        public async Task UpdateTodoAsync(UpdateTodoDto updateTodoDto)
        {
            var todoItem = new TodoItem
            {
                Id = updateTodoDto.Id,
                Title = updateTodoDto.Title
            };

            await _todoRepository.UpdateTodoAsync(todoItem);
        }

        public async Task DeleteTodoAsync(int id)
        {
            await _todoRepository.DeleteTodoAsync(id);
        }
    }
}