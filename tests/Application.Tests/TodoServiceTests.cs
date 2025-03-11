using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Application.Interfaces;
using Application.Features.Todo.Commands;
using Application.Features.Todo.Handlers;
using Domain.Entities;

namespace Application.Tests
{
    public class TodoServiceTests
    {
        private readonly Mock<ITodoService> _todoServiceMock;
        private readonly CreateTodoHandler _handler;

        public TodoServiceTests()
        {
            _todoServiceMock = new Mock<ITodoService>();
            _handler = new CreateTodoHandler(_todoServiceMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldCreateTodo_WhenCommandIsValid()
        {
            var command = new CreateTodoCommand { Title = "Test Todo", Description = "Test Description" };
            var todoItem = new TodoItem { Id = 1, Title = command.Title, Description = command.Description };

            _todoServiceMock.Setup(x => x.CreateTodo(It.IsAny<TodoItem>())).ReturnsAsync(todoItem);

            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(command.Title, result.Title);
            _todoServiceMock.Verify(x => x.CreateTodo(It.IsAny<TodoItem>()), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldThrowException_WhenTodoServiceFails()
        {
            var command = new CreateTodoCommand { Title = "Test Todo", Description = "Test Description" };

            _todoServiceMock.Setup(x => x.CreateTodo(It.IsAny<TodoItem>())).ThrowsAsync(new System.Exception("Service error"));

            await Assert.ThrowsAsync<System.Exception>(() => _handler.Handle(command, CancellationToken.None));
            _todoServiceMock.Verify(x => x.CreateTodo(It.IsAny<TodoItem>()), Times.Once);
        }
    }
}