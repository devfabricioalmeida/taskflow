using System;
using System.Collections.Generic;
using Taskflow.Core.Domain;

namespace TaskFlow.GerenciamentoTarefas.Domain.Tarefas
{
    public class Tarefa : Entity, IAggregateRoot
    {
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataPrevisaoEntrega { get; private set; }
        public DateTime DataInicio { get; private set; }
        public int? ResponsalvelId { get; private set; }
        public int FluxoTrabalhoId { get; private set; }
        public TipoTarefa Tipo { get; private set; }
        public StatusTarefa StatusTarefa { get; private set; }

        public Area Area { get; private set; }
        public Responsavel Responsavel { get; private set; }
        public int Prioridade { get; private set; }

        private readonly List<Interacao> _interacoes = new();
        public IReadOnlyCollection<Interacao> Interacoes => _interacoes;

        private readonly List<Anexo> _anexos = new();
        public IReadOnlyCollection<Anexo> Anexos => _anexos;

        protected Tarefa() { }

        public Tarefa(string titulo, string descricao)
        {
            Titulo = titulo;
            Descricao = descricao;
        }

        public void AtribuirResponsavel(Responsavel responsavel)
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

        public void AlterarDataEntrega(DateTime novaData)
        {
            if (StatusTarefa == StatusTarefa.Concluido || StatusTarefa == StatusTarefa.Cancelado)
            {
                throw new Exception("Nao é possível alterar a data de previsão de entrega para tarefa BLOQUEDA OU CANCELADA");
            }

            DataPrevisaoEntrega = novaData;
        }
    }

    public enum TipoTarefa
    {
        Correcao,
        Implementacao
    }
    public enum StatusTarefa
    {
        Ativo,
        Cancelado,
        Concluido,
        Bloqueado
    }
}
