using EmployeeDirectory.Application.Interfaces.IRepository;
using System.Collections.Generic;

namespace EmployeeDirectory.Application.DTOs.ReturnDTO
{
    /// <summary>
    /// DTO, возвращаемое из метода 
    /// <see cref="IEmployeeRepository.Search(string)"/>
    /// </summary>
    public class SearchReturnDTO
    {
        /// <summary>
        /// Список подходящих сотрудников
        /// </summary>
        public List<EmployeeLookup> Employees { get; set; } = new List<EmployeeLookup>();
    }
}
