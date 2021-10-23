using Taskflow.Core.Domain;

namespace TaskFlow.GerenciamentoTarefas.Domain.Tarefas
{
    public class Usuario : Entity, IAggregateRoot
    {
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
