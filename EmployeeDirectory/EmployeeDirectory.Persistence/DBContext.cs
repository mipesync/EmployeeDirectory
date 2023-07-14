using EmployeeDirectory.Application.Interfaces;
using EmployeeDirectory.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EmployeeDirectory.Persistence
{
    /// <inheritdoc/>
    public class DBContext : DbContext, IDBContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
