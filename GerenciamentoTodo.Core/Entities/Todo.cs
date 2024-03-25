namespace GerenciamentoTodo.Core.Entities
{
    public class Todo
    {
        public Todo(string titulo, string descricao, DateTime? dataConclusao)
        {
            Titulo = titulo;
            Descricao = descricao;
            DataCriacao = DateTime.Now;
            DataConclusao = dataConclusao;
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataConclusao { get; set; }
        public int UsuarioId { get; set; }

        public void Update(string? titulo, string? descricao, DateTime? dataConclusao)
        {
            if (titulo != null)
            {
                Titulo = titulo;
            }

            if (descricao != null)
            {
                Descricao = descricao;
            }

            if (dataConclusao.HasValue)
            {
                DataConclusao = dataConclusao;
            }
        }
    }
}
