using System;
using System.Threading.Tasks;
using Taskflow.Core.Domain;

namespace Taskflow.Core.Data
{
    public interface IRepository<TEntity> : IDisposable where TEntity : IAggregateRoot
    {
        Task<TEntity> GetById(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        Task<bool> Commit();
    }
}
