﻿using EmployeeDirectory.Domain;
using EmployeeDirectory.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EmployeeDirection.Tests.Common
{
    /// <summary>
    /// Тестовый контекст базы данных
    /// </summary>
    public class TestDBContext
    {
        /// <summary>
        /// Идентификатор первого сотрудника из бд
        /// </summary>
        public static Guid EmployeeId { get; private set; } = Guid.Empty;

        /// <summary>
        /// Создание тестового контекста базы данных
        /// </summary>
        /// <returns>Тестовый контекст базы данных</returns>
        public static DBContext Create()
        {
            var options = new DbContextOptionsBuilder<DBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new DBContext(options);
            context.Database.EnsureCreated();

            for (int i = 0; i < 50; i++)
            {
                var employeeId = Guid.NewGuid();

                if (EmployeeId == Guid.Empty) 
                    EmployeeId = employeeId;

                var employee = new Employee
                {
                    Id = employeeId,
                    FirstName = "Сотрудник" + i,
                    LastName = "Сотрудников" + i,
                    MiddleName = "Сотрудникович" + i,
                    FullName = $"Сотрудников{i} Сотрудник{i} Сотрудникович{i}",
                    Department = "Отдел " + i,
                    PhoneNumber = "79999999999"
                        .Substring(0, 11 - i.ToString().Length) + i
                };

                context.Employees.Add(employee);
            }

            context.SaveChanges();
            return context;
        }

        /// <summary>
        /// Уничтожить тестовую базу данных и её контекст
        /// </summary>
        /// <param name="context">Тестовый контекст базы данных</param>
        public static void Destroy(DBContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
