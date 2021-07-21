using System;
using Taskflow.Core.Domain;

namespace TaskFlow.GerenciamentoTarefas.Domain.Tarefas
{

	public class Interacao : Entity
    {
        public int TarefaId { get; private set; }
        public int UsuarioId { get; private set; }
        public string Descricao { get; private set; }

        public Interacao(int usuarioId, int tarefaId, string conteudo)
        {
            UsuarioId = usuarioId;
            TarefaId = tarefaId;
            Descricao = conteudo;

            if (usuarioId <= 0)
                throw new Exception("O usuário não foi informado.");

            if (tarefaId <= 0)
                throw new Exception("A tarefa não foi realicionada a interação");

            if (string.IsNullOrWhiteSpace(conteudo) || string.IsNullOrEmpty(conteudo))
                throw new Exception("O conteudo da interação não informado.");
        }
    }
}
