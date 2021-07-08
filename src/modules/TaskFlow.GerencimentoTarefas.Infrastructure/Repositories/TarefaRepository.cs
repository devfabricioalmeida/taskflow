using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaskFlow.GerenciamentoTarefas.Domain.Repositories;
using TaskFlow.GerenciamentoTarefas.Domain.Tarefas;
using TaskFlow.GerencimentoTarefas.Infrastructure.DbContexts;

namespace TaskFlow.GerencimentoTarefas.Infrastructure.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly GerenciamentoTarefasContext _context;

        public TarefaRepository(GerenciamentoTarefasContext context)
        {
            _context = context;
        }

        public void Add(Tarefa entity)
        {
            _context.Add(entity);
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<Tarefa> GetById(int id)
        {
            return _context.Tarefas.FirstOrDefaultAsync(t => t.Id == id);
        }

        public void Update(Tarefa entity)
        {
            _context.Update(entity);
        }
    }
}
