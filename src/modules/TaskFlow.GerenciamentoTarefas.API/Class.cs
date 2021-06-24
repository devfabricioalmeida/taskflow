using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskFlow.GerenciamentoTarefas.Domain.Tarefas;

namespace TaskFlow.GerenciamentoTarefas.API
{
    public class Class
    {
        public Class()
        {
            var fabricio = new Responsavel();

            var tarefa = new Tarefa("Teste", "testedas dasd");
            tarefa.AbribuirResponsavel(fabricio);

        }
    }
}
