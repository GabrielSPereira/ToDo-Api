namespace GerenciamentoTodo.Core.Entities
{
    public class Todo
    {
        public Todo() 
        { 
            DataCriacao = DateTime.Now;
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataConclusao { get; set; }
        public int UsuarioId { get; set; }

        public void Update(string titulo, string descricao, DateTime dataConclusao)
        {
            Titulo = titulo;
            Descricao = descricao;
            DataConclusao = dataConclusao;
        }
    }
}
