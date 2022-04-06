using System;
using System.Threading;
using System.Threading.Tasks;

namespace RevendaCarro.Domain.UnitOfWork.Interface
{
    public interface IUofW : IDisposable
    {
        Task SaveChanges(CancellationToken cancellationToken = default);
    }
}
