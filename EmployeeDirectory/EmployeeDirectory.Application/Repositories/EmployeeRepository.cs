using EmployeeDirectory.Application.DTOs;
using EmployeeDirectory.Application.Interfaces.IRepositories;
using EmployeeDirectory.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeDirectory.Application.Repositories
{
    /// <inheritdoc/>
    public class EmployeeRepository : IEmployeeRepository
    {
        public Guid Add(AddEmployeeDTO dto)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll(GetAllDTO dto)
        {
            throw new NotImplementedException();
        }

        public Employee GetById(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public List<Employee> Search(string query)
        {
            throw new NotImplementedException();
        }

        public string UploadPhoto(UploadPhotoDTO dto, string webRootPath, string hostUrl)
        {
            throw new NotImplementedException();
        }

        public Task Update(UpdateDetailsDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
