using GerenciamentoTodo.Application.Models.Todo;
using GerenciamentoTodo.Application.Models.User;
using GerenciamentoTodo.Application.Services.Implementations;
using GerenciamentoTodo.Application.Services.Interfaces;
using GerenciamentoTodo.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GerenciamentoTodos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post(UserAddInput input)
        {
            try
            {
                var user = new User(input.Nome);
                _userService.CreateUser(user);
                return Ok(user);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpGet("Login/{nome}")]
        [AllowAnonymous]
        public IActionResult Login(string nome)
        {
            var loginUserViewModel = _userService.Login(nome);
            if (loginUserViewModel is null)
            {
                return BadRequest();
            }

            return Ok(loginUserViewModel);
        }
    }
}
