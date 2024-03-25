using GerenciamentoTodo.Core.Entities;

namespace GerenciamentoTodo.Infrastructure.Repositories.Interfaces
{
    public interface ITodoRepository
    {
        IEnumerable<Todo> GetAll();
        Todo? GetById(int id);
        void Add(Todo todo);
        void Update(Todo todo);
        void Delete(Todo todo);
    }
}
