namespace GerenciamentoTodo.Core.Entities
{
    public class User
    {
        public User(string nome)
        {
            Nome = nome;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
