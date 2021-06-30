using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskFlow.GerencimentoTarefas.API.Models.Inputs
{
    public class TarefaInputModel
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int ResponsavelId { get; set; }
    }
}
