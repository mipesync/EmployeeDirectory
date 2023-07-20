using AutoMapper;
using EmployeeDirectory.Application.DTOs;
using EmployeeDirectory.Application.Exceptions;
using EmployeeDirectory.Application.Interfaces;
using EmployeeDirectory.Application.Interfaces.IRepository;
using EmployeeDirectory.Domain;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Employee>> GetAll(GetAllDTO dto)
        {
            var employees = await _dbContext.Employees.ToListAsync(CancellationToken.None);

            return employees;
        }

        public async Task<Employee> GetById(Guid employeeId)
        {
            var employee = await _dbContext.Employees
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == employeeId, CancellationToken.None);

            if (employee is null)
                throw new NotFoundException(employee);

            return employee;
        }

        public Task<List<Employee>> Search(string query)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> Add(AddEmployeeDTO dto)
        {
            var isAlreadyExist = _dbContext.Employees.Any(u => 
                u.PhoneNumber == dto.PhoneNumber);

            if (isAlreadyExist)
                throw new AlreadyExistException("Сотрудник с таким номером " +
                    "телефона уже существует");

            var employee = _mapper.Map<Employee>(dto);

            await _dbContext.Employees.AddAsync(employee, CancellationToken.None);
            await _dbContext.SaveChangesAsync(CancellationToken.None);

            return employee.Id;
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
