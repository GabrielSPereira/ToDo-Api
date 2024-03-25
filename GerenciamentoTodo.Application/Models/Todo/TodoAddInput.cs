namespace GerenciamentoTodo.Application.Models.Todo
{
    public class TodoAddInput
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataConclusao { get; set; }
    }
}
