using GerenciamentoTodo.Core.Entities;

namespace GerenciamentoTodo.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User? GetUserByName(string nome);
        void Add(User user);

    }
}
