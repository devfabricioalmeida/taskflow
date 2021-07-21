using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskflow.Core.Domain;

namespace TaskFlow.GerenciamentoTarefas.Domain.Tarefas
{
    public class Responsavel : Entity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public Responsavel()
        {
        }

        public void Bloquear()
        {

        }
    }
}
