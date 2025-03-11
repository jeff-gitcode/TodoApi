using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Features.Todo.Commands;
using Application.Features.Todo.Queries;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDto>>> GetTodos()
        {
            var query = new GetTodosQuery();
            var todos = await _mediator.Send(query);
            return Ok(todos);
        }

        [HttpPost]
        public async Task<ActionResult<TodoItemDto>> CreateTodo([FromBody] CreateTodoCommand command)
        {
            var todo = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetTodoById), new { id = todo.Id }, todo);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDto>> GetTodoById(int id)
        {
            var query = new GetTodoByIdQuery { Id = id };
            var todo = await _mediator.Send(query);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        // Additional CRUD operations can be added here (Update, Delete)
    }
}