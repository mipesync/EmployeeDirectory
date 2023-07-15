using EmployeeDirectory.Application.DTOs;
using EmployeeDirectory.Domain;
using System.Collections.Generic;

namespace EmployeeDirectory.Application.Interfaces.IRepositories
{
    /// <summary>
    /// Интерфейс, описывающий методы операций над сотрудниками
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Получить список сотрудников
        /// </summary>
        /// <param name="dto">Входные данные</param>
        /// <returns>Список сотрудников</returns>
        List<Employee> GetAll(GetAllDTO dto);
    }
}
