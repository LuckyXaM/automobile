using System;
using System.Threading;
using System.Threading.Tasks;

namespace AutoRepository.Data.Infrastructure
{
    /// <summary>
    /// Интерфейс для сохранения данных
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Сохраняет данные
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
