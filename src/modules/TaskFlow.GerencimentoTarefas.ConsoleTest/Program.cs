using System;
using TaskFlow.GerenciamentoTarefas.Domain.Usuarios;

namespace TaskFlow.GerencimentoTarefas.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var usuario1 = new Usuario();
            usuario1.Nome = "FABRICIO ALMEIDA";
            usuario1.AlterarSenha("21");


        }
    }
}
