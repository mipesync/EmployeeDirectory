using EmployeeDirectory.Application.Interfaces.IRepository;
using EmployeeDirectory.Application.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeDirectory.Application
{
    /// <summary>
    /// Внедрение зависимостей
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Внедрить в сервисы зависимости <see cref="Application"/>
        /// </summary>
        /// <param name="services">Существующие сервисы</param>
        /// <returns>Обновлённые сервисы</returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}
