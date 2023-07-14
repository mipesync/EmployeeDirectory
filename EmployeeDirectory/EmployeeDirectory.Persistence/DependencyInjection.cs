using EmployeeDirectory.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeDirectory.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<DBContext>(option => option.UseSqlite(connectionString));
            services.AddScoped<IDBContext>(provider => provider.GetService<DBContext>());

            return services;
        }
    }
}
