using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.GerenciamentoTarefas.Domain
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; private set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;
            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

    }
}
