using System;
using System.Threading.Tasks;

namespace TaskFlow.GerenciamentoTarefas.Domain.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : IAggregateRoot
    {
        Task<TEntity> GetById(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        Task<bool> Commit();
    }
}
