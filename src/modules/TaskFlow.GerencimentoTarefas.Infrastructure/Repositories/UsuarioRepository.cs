using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.GerenciamentoTarefas.Domain.Repositories;
using TaskFlow.GerenciamentoTarefas.Domain.Tarefas;
using TaskFlow.GerencimentoTarefas.Infrastructure.DbContexts;

namespace TaskFlow.GerencimentoTarefas.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly GerenciamentoTarefasContext _context;

        public UsuarioRepository(GerenciamentoTarefasContext context)
        {
            _context = context;
        }

        public void Add(Usuario entity)
        {
            _context.Usuarios.Add(entity);
        }

        public async Task<bool> Commit()
        {
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<Usuario> GetById(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public void Update(Usuario entity)
        {
            _context.Usuarios.Update(entity);
        }
    }
}
