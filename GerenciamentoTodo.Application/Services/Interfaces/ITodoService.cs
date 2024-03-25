using GerenciamentoTodo.Core.Entities;

namespace GerenciamentoTodo.Application.Services.Interfaces
{
    public interface ITodoService
    {
        IEnumerable<Todo> GetAllTodos();
        Todo GetTodoById(int id);
        void CreateTodo(Todo todo);
        bool UpdateTodo(int id, Todo todo);
        bool DeleteTodo(int id);
    }
}
