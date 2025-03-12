using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(int id, [FromBody] UpdateTodoCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);
            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var command = new DeleteTodoCommand { Id = id };
            var result = await _mediator.Send(command);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}