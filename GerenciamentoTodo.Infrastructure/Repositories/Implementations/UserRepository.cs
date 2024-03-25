using GerenciamentoTodo.Core.Entities;
using GerenciamentoTodo.Infrastructure.Persistence;
using GerenciamentoTodo.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;

namespace GerenciamentoTodo.Infrastructure.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly GerenciamentoTodoDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRepository(GerenciamentoTodoDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public User? GetUserByName(string nome) => _context.Users.SingleOrDefault(x => x.Nome == nome);

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

    }
}
