using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskFlow.GerencimentoTarefas.API.Models.Views
{
    public class TarefaViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Titulo { get; set; }
        public int ReposavelId { get; set; }
        public string Responsavel { get; set; }
    }
}
