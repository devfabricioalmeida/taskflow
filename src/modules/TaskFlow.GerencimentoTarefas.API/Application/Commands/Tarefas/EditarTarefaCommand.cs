namespace TaskFlow.GerencimentoTarefas.API.Application.Commands.Tarefas
{
    public class EditarTarefaCommand
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int ResponsavelId { get; set; }
    }
}
