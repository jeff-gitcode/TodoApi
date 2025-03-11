using Xunit;
using TodoApi.Domain.Entities;

namespace TodoApi.Domain.Tests
{
    public class TodoItemTests
    {
        [Fact]
        public void TodoItem_CanBeCreated_WithValidParameters()
        {
            // Arrange
            var title = "Test Todo";
            var description = "Test Description";
            var status = TodoStatus.Pending;

            // Act
            var todoItem = new TodoItem(title, description, status);

            // Assert
            Assert.NotNull(todoItem);
            Assert.Equal(title, todoItem.Title);
            Assert.Equal(description, todoItem.Description);
            Assert.Equal(status, todoItem.Status);
        }

        [Fact]
        public void TodoItem_ThrowsException_WhenTitleIsNull()
        {
            // Arrange
            string title = null;
            var description = "Test Description";
            var status = TodoStatus.Pending;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new TodoItem(title, description, status));
        }

        [Fact]
        public void TodoItem_ThrowsException_WhenStatusIsInvalid()
        {
            // Arrange
            var title = "Test Todo";
            var description = "Test Description";
            var status = (TodoStatus)999; // Invalid status

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new TodoItem(title, description, status));
        }
    }
}