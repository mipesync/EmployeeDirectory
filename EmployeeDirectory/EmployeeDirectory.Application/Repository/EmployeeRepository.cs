using AutoMapper;
using EmployeeDirectory.Application.DTOs;
using EmployeeDirectory.Application.Exceptions;
using EmployeeDirectory.Application.Interfaces;
using EmployeeDirectory.Application.Interfaces.IRepository;
using EmployeeDirectory.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeDirectory.Application.Repository
{
    /// <inheritdoc/>
    /// Репозиторий с методами операций над сотрудниками
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDBContext _dbContext;
        private readonly IMapper _mapper;

        public EmployeeRepository(IDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Task<List<Employee>> GetAll(GetAllDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetById(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> Search(string query)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> Add(AddEmployeeDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<string> UploadPhoto(UploadPhotoDTO dto, string webRootPath, 
            string hostUrl)
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
