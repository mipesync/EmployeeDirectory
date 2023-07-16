﻿using EmployeeDirectory.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeDirectory.Persistence
{
    /// <summary>
    /// Внедрение зависимостей
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Внедрить в сервисы зависимости <see cref="Persistence"/>
        /// </summary>
        /// <param name="services">Существующие сервисы</param>
        /// <returns>Обновлённые сервисы</returns>
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<DBContext>(option => option.UseSqlite(connectionString));
            services.AddScoped<IDBContext>(provider => provider.GetService<DBContext>());

            return services;
        }
    }
}
