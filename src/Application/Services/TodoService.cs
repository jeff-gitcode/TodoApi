using Application.DTOs;
using Application.Features.Todo.Queries;
using Application.Interfaces;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<IEnumerable<TodoItemDto>> GetAllTodosAsync()
        {
            var todos = await _todoRepository.GetAllTodosAsync();
            return todos.Select(t => new TodoItemDto
            {
                Id = t.Id,
                Title = t.Title,
            }).ToList();
        }

        public async Task<TodoItemDto?> GetTodoByIdAsync(int id)
        {
            var todo = await _todoRepository.GetTodoByIdAsync(id);
            if (todo == null)
            {
                return null;
            }

            return new TodoItemDto
            {
                Id = todo.Id,
                Title = todo.Title,
            };
        }

        public async Task<TodoItemDto> CreateTodoAsync(TodoItemDto todoItemDto)
        {
            var todo = new TodoItem
            {
                Title = todoItemDto.Title,
            };

            todo = await _todoRepository.AddTodoAsync(todo);

            todoItemDto.Id = todo.Id;

            return todoItemDto;
        }

        public async Task UpdateTodoAsync(TodoItemDto todoItemDto)
        {
            var todo = new TodoItem
            {
                Id = todoItemDto.Id,
                Title = todoItemDto.Title,
            };

            await _todoRepository.UpdateTodoAsync(todo);
        }

        public async Task DeleteTodoAsync(int id)
        {
            await _todoRepository.DeleteTodoAsync(id);
        }
    }
}