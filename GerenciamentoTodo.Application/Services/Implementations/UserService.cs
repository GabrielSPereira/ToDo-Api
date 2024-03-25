using GerenciamentoTodo.Application.Models.User;
using GerenciamentoTodo.Application.Services.Interfaces;
using GerenciamentoTodo.Core.Entities;
using GerenciamentoTodo.Infrastructure.Repositories.Implementations;
using GerenciamentoTodo.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GerenciamentoTodo.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public UserService(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public LoginUserViewModel? Login(string nome)
        {
            var user = _userRepository.GetUserByName(nome);
            if(user == null)
            {
                return null;
            }

            var token = _authService.GenerateJwtToken(user);

            var loginUserViewModel = new LoginUserViewModel(user.Nome, token);

            return loginUserViewModel;
        }

        public void CreateUser(User todo)
        {
            _userRepository.Add(todo);
        }
    }
}
