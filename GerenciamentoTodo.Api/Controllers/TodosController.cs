using GerenciamentoTodo.Application.Models.Todo;
using GerenciamentoTodo.Application.Services.Interfaces;
using GerenciamentoTodo.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoTodos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class TodosController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TodosController(ITodoService todoService, IHttpContextAccessor httpContextAccessor)
        {
            _todoService = todoService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var todos = _todoService.GetAllTodos();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var todo = _todoService.GetTodoById(id);
            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }

        [HttpPost]
        public IActionResult Post(TodoAddInput input)
        {
            var todo = new Todo(input.Titulo, input.Descricao, input.DataConclusao);
            _todoService.CreateTodo(todo);
            return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TodoUpdateInput input)
        {
            var todo = new Todo(input.Titulo, input.Descricao, input.DataConclusao);
            var updated = _todoService.UpdateTodo(id, todo);
            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _todoService.DeleteTodo(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
