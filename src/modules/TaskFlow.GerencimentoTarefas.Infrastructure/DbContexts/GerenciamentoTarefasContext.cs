using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.GerenciamentoTarefas.Domain.Tarefas;

namespace TaskFlow.GerencimentoTarefas.Infrastructure.DbContexts
{
    public class GerenciamentoTarefasContext : DbContext
    {
        public GerenciamentoTarefasContext(DbContextOptions<GerenciamentoTarefasContext> options) : base(options){}

        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Responsavel> Resposaveis { get; set; }
        public DbSet<Interacao> Interacoes { get; set; }


    }
}
