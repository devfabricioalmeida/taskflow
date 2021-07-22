using System;
using System.Collections.Generic;
using System.Linq;
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
        public StatusTarefa Status { get; private set; }

        public Area Area { get; private set; }
        public Responsavel Responsavel { get; private set; }
        public int Prioridade { get; private set; }

        private readonly List<Interacao> _interacoes = new();
        public IReadOnlyCollection<Interacao> Interacoes => _interacoes;

        private readonly List<Anexo> _anexos = new();
        public IReadOnlyCollection<Anexo> Anexos => _anexos;

        protected Tarefa() { }

        public Tarefa(string titulo, string descricao, TipoTarefa tipo)
        {
            Titulo = titulo;
            Descricao = descricao;
            Tipo = tipo;
            Status = StatusTarefa.Ativo;
        }

        public void AtribuirResponsavel(Responsavel responsavel)
        {
            if (Responsavel != null)
                throw new Exception("Já existe um reponsável atruido a tarefa.");

            Responsavel = responsavel;
        }

        public void ProrrogarPrevisaoEntrega(DateTime novaPrevisao)
        {
            if (novaPrevisao.Date < DateTime.Now.Date)
                throw new Exception("A nova data de previsão não pode ser menor que a data atual.");

            if (TarefaEstaFinalizada())
                throw new Exception("Nao é possível alterar a data de previsão de entrega para tarefa CONCLUIDA OU CANCELADA");

            DataPrevisaoEntrega = novaPrevisao;
        }

        public void AdicionarInteracao(int usuarioId, string descricao)
        {
            if (TarefaEstaFinalizada())
                throw new Exception("Nao é possível adicionar uma interação para tarefa CONCLUIDA OU CANCELADA");

            _interacoes.Add(new Interacao(usuarioId, Id, descricao));
        }

        public void Bloquear()
        {
            if (TarefaEstaFinalizada())
                throw new Exception("Nao é possível bloquear uma tarefa CONCLUIDA OU CANCELADA");

            Status = StatusTarefa.Bloqueado;
        }

        public void Desbloquear()
        {
            if (Status != StatusTarefa.Bloqueado)
                throw new Exception("Nao é possível desbloquear uma tarefa que não esteja bloqueada.");

            Status = StatusTarefa.Ativo;
        }

        public void Cancelar()
        {
            if (TarefaEstaFinalizada())
                throw new Exception("Nao é possível cancelar uma tarefa CONCLUIDA OU CANCELADA.");

            Status = StatusTarefa.Cancelado;
        }

        public void Concluir()
        {
            if (Status != StatusTarefa.Ativo)
                throw new Exception("Nao é possível cancelar uma tarefa que não esteja ATIVA.");

            Status = StatusTarefa.Concluido;
        }

        private bool TarefaEstaFinalizada()
        {
            return Status == StatusTarefa.Concluido || Status == StatusTarefa.Cancelado;
        }

        public void RemoverInteracao(int interacaoId)
        {
            if (TarefaEstaFinalizada())
                throw new Exception("Não é possível remover uma interação de uma tarefa FINALIZADA.");

            var interacaoExiste = _interacoes.FirstOrDefault(i => i.Id == interacaoId);

            if (interacaoExiste == null)
                throw new Exception($"A interação de id {interacaoId} não pertence a tarefa.");


            _interacoes.Remove(interacaoExiste);


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
