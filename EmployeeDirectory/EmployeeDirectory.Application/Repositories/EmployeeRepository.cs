using EmployeeDirectory.Application.DTOs;
using EmployeeDirectory.Application.Interfaces.IRepositories;
using EmployeeDirectory.Domain;
using System;
using System.Collections.Generic;

namespace EmployeeDirectory.Application.Repositories
{
    /// <inheritdoc/>
    public class EmployeeRepository : IEmployeeRepository
    {
        public List<Employee> GetAll(GetAllDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
