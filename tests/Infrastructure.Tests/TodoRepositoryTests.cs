using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Xunit;
using TodoApi.Infrastructure.Repositories;
using TodoApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Infrastructure.Tests
{
    public class TodoRepositoryTests
    {
        private readonly Mock<TodoDbContext> _mockContext;
        private readonly TodoRepository _repository;

        public TodoRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<TodoDbContext>()
                .UseInMemoryDatabase(databaseName: "TodoTestDb")
                .Options;

            _mockContext = new Mock<TodoDbContext>(options);
            _repository = new TodoRepository(_mockContext.Object);
        }

        [Fact]
        public async Task GetAllTodos_ReturnsAllTodos()
        {
            // Arrange
            var todos = new List<TodoItem>
            {
                new TodoItem { Id = 1, Title = "Test Todo 1", Description = "Description 1", Status = TodoStatus.Pending },
                new TodoItem { Id = 2, Title = "Test Todo 2", Description = "Description 2", Status = TodoStatus.Completed }
            };

            _mockContext.Setup(m => m.TodoItems).ReturnsDbSet(todos);

            // Act
            var result = await _repository.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task CreateTodo_AddsTodoToDatabase()
        {
            // Arrange
            var todo = new TodoItem { Title = "New Todo", Description = "New Description", Status = TodoStatus.Pending };

            // Act
            await _repository.CreateAsync(todo);
            await _mockContext.SaveChangesAsync();

            // Assert
            Assert.Equal(1, await _mockContext.TodoItems.CountAsync());
        }

        [Fact]
        public async Task GetTodoById_ReturnsTodo()
        {
            // Arrange
            var todo = new TodoItem { Id = 1, Title = "Test Todo", Description = "Description", Status = TodoStatus.Pending };
            _mockContext.Setup(m => m.TodoItems.FindAsync(1)).ReturnsAsync(todo);

            // Act
            var result = await _repository.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test Todo", result.Title);
        }

        [Fact]
        public async Task DeleteTodo_RemovesTodoFromDatabase()
        {
            // Arrange
            var todo = new TodoItem { Id = 1, Title = "Test Todo", Description = "Description", Status = TodoStatus.Pending };
            _mockContext.Setup(m => m.TodoItems.FindAsync(1)).ReturnsAsync(todo);
            await _repository.CreateAsync(todo);
            await _mockContext.SaveChangesAsync();

            // Act
            await _repository.DeleteAsync(1);
            await _mockContext.SaveChangesAsync();

            // Assert
            Assert.Equal(0, await _mockContext.TodoItems.CountAsync());
        }
    }
}