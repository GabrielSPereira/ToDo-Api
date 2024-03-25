namespace GerenciamentoTodo.Application.Models.Todo
{
    public class TodoUpdateInput
    {
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime? DataConclusao { get; set; }
    }
}
