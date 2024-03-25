using GerenciamentoTodo.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GerenciamentoTodo.Infrastructure.Persistence
{
    public class GerenciamentoTodoDbContext : DbContext
    {
        public GerenciamentoTodoDbContext(DbContextOptions<GerenciamentoTodoDbContext> options) : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
