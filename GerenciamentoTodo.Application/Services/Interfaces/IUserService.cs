using GerenciamentoTodo.Application.Models.User;
using GerenciamentoTodo.Core.Entities;

namespace GerenciamentoTodo.Application.Services.Interfaces
{
    public interface IUserService
    {
        LoginUserViewModel Login(string nome);
        void CreateUser(User user);

    }
}
