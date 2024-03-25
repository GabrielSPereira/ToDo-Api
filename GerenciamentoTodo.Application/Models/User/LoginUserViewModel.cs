using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoTodo.Application.Models.User
{
    public class LoginUserViewModel
    {
        public LoginUserViewModel(string nome, string token)
        {
            Nome = nome;
            Token = token;
        }

        public string Nome { get; set; }
        public string Token { get; set; }
    }
}
