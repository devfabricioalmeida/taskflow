using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.GerenciamentoTarefas.Domain.Tarefas
{
    public class Tarefa : Entity
    {
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataPrevisaoEntrega { get; private set; }
        public DateTime DataInicio { get; private set; }
        public Responsavel Responsavel { get; private set; }


        private readonly List<Interacao> _interacoes = new List<Interacao>();

        public IReadOnlyCollection<Interacao> Interacoes => _interacoes;

        public Tarefa(string titulo, string descricao)
        {
            Titulo = titulo;
            Descricao = descricao;
        }

        public void AbribuirResponsavel(Responsavel responsavel)
        {
            if (Responsavel != null)
                throw new Exception("Já existe um reponsável atruido a tarefa.");

            Responsavel = responsavel;
        }

        public void AlterarDataPrevisao(DateTime novaPrevisao)
        {
            if (novaPrevisao.Date < DateTime.Now.Date)
                throw new Exception("A nova data de previsão não pode ser menor que a data atual.");

            DataPrevisaoEntrega = novaPrevisao;
        }

        public void AdicionarInteracao(Interacao interacao)
        {
            _interacoes.Add(interacao);
        }

    }
}
