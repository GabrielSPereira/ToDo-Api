using GerenciamentoTodo.Application.Services.Interfaces;
using GerenciamentoTodo.Core.Entities;
using GerenciamentoTodo.Infrastructure.Repositories.Interfaces;

namespace GerenciamentoTodo.Application.Services.Implementations
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public IEnumerable<Todo> GetAllTodos()
        {
            return _todoRepository.GetAll();
        }

        public Todo? GetTodoById(int id)
        {
            return _todoRepository.GetById(id);
        }

        public void CreateTodo(Todo todo)
        {
            _todoRepository.Add(todo);
        }

        public bool UpdateTodo(int id, Todo todo)
        {
            var existingTodo = _todoRepository.GetById(id);
            if (existingTodo != null)
            {
                existingTodo.Update(todo.Titulo, todo.Descricao, todo.DataConclusao);
                _todoRepository.Update(existingTodo);
                return true;
            }

            return false;
        }

        public bool DeleteTodo(int id)
        {
            var existingTodo = _todoRepository.GetById(id);
            if (existingTodo != null)
            {
                _todoRepository.Delete(existingTodo);
                return true;
            }

            return false;
        }
    }
}
