using System;

using System.Threading.Tasks;
using RevendaCarro.Domain.Entities;

namespace RevendaCarro.Infra.Repositories.Interface
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : Entity
    {
        Task<TEntity> Add(TEntity entity);
    }
}
