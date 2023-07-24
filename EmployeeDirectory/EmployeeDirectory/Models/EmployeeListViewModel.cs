using EmployeeDirectory.Application.DTOs;
using EmployeeDirectory.Domain;
using System.Collections.Generic;

namespace EmployeeDirectory.Web.Models
{
    /// <summary>
    /// Модель списка сотрудников
    /// </summary>
    public class EmployeeListViewModel
    {
        /// <summary>
        /// Список сотрудников
        /// </summary>
        public List<Employee> Employees { get; set; } = new List<Employee>();
        /// <summary>
        /// Параметры вывода
        /// </summary>
        public GetAllDTO Params { get; set; }
    }
}
