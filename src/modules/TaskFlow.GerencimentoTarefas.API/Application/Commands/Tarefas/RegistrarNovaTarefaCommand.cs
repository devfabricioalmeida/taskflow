using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskFlow.GerencimentoTarefas.API.Application.Commands.Tarefas
{
    public class RegistrarNovaTarefaCommand
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int ResponsavelId { get; set; }
    }
}
