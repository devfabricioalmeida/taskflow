using TaskFlow.GerenciamentoTarefas.Domain.Tarefas;
using TaskFlow.GerencimentoTarefas.API.Models.Views;

namespace TaskFlow.GerencimentoTarefas.API.Models.Mappings
{
    public static class TarefaMapping
    {
        public static TarefaViewModel ParaViewModel(this Tarefa tarefa)
        {
            var tarefaViewModel = new TarefaViewModel();
            tarefaViewModel.Descricao = tarefa.Descricao;
            tarefaViewModel.Titulo = tarefa.Titulo;
            //tarefaViewModel.Responsavel = tarefa.Responsavel.Nome;
            //tarefaViewModel.ReposavelId = tarefa.Responsavel.Id;

            return tarefaViewModel;
        }


    }
}
