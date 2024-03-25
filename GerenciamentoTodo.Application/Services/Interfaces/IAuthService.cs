using GerenciamentoTodo.Core.Entities;

namespace GerenciamentoTodo.Application.Services.Interfaces
{
    public interface IAuthService
    {
        string GenerateJwtToken(User user);
    }
}
