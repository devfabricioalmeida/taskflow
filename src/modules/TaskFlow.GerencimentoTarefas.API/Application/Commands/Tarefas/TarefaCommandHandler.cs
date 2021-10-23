using System.Threading.Tasks;
using TaskFlow.GerenciamentoTarefas.Domain.Repositories;
using TaskFlow.GerenciamentoTarefas.Domain.Tarefas;

namespace TaskFlow.GerencimentoTarefas.API.Application.Commands.Tarefas
{
    public class TarefaCommandHandler
    {
        private readonly ITarefaRepository _tarefaReposity;

        public TarefaCommandHandler(ITarefaRepository tarefaReposity)
        {
            _tarefaReposity = tarefaReposity;
        }

        public async Task Handle(RegistrarNovaTarefaCommand command)
        {
            var tarefa = new Tarefa(command.Titulo, command.Descricao, TipoTarefa.Implementacao);



            _tarefaReposity.Add(tarefa);

            var retorno = await _tarefaReposity.Commit();

        }


        public async Task Handle(EditarTarefaCommand command)
        {
            Tarefa tarefa = await _tarefaReposity.GetById(command.Id);

        }
    }

}
