using System.Linq;
using System.Security.Claims;
using GerenciamentoTodo.Core.Entities;
using GerenciamentoTodo.Infrastructure.Persistence;
using GerenciamentoTodo.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;

namespace GerenciamentoTodo.Infrastructure.Repositories.Implementations
{
    public class TodoRepository : ITodoRepository
    {
        private readonly GerenciamentoTodoDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TodoRepository(GerenciamentoTodoDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public IEnumerable<Todo> GetAll()
        {
            return _context.Todos.Where(todo => todo.UsuarioId == GetCurrentUserId()).ToList();
        }

        public Todo? GetById(int id) => _context.Todos.SingleOrDefault(x => x.Id == id && x.UsuarioId == GetCurrentUserId());

        public void Add(Todo todo)
        {
            todo.UsuarioId = GetCurrentUserId();

            _context.Todos.Add(todo);
            _context.SaveChanges();
        }

        public void Update(Todo todo)
        {
            _context.Update(todo);
            _context.SaveChanges();
        }

        public void Delete(Todo todo)
        {
            _context.Remove(todo);
            _context.SaveChanges();
        }

        private int GetCurrentUserId()
        {
            var currentUserId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            int userId;
            if (int.TryParse(currentUserId, out userId))
            {
                return userId;
            }
            else
            {
                throw new Exception("Token inválido.");
            }
        }
    }
}
