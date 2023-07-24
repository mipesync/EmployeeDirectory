using EmployeeDirectory.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeDirectory.Application.Interfaces
{
    /// <summary>
    /// Интерфейс, описывающий контекст базы данных
    /// </summary>
    public interface IDBContext
    {
        /// <summary>
        /// Таблица сотрудников
        /// </summary>
        DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// Сохранить изменения ассинхронно
        /// </summary>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
