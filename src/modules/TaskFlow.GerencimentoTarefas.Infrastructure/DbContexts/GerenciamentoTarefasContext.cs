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
        public GerenciamentoTarefasContext(DbContextOptions<GerenciamentoTarefasContext> options) : base(options) { }

        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Interacao> Interacoes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(p => p.GetProperties().Where(t => t.ClrType == typeof(string))))
            {
                int? nullableMaxLength = property.GetMaxLength();

                int maxLength = nullableMaxLength ?? 100;

                property.SetColumnType($"VARCHAR({maxLength})");
            }
  
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GerenciamentoTarefasContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
