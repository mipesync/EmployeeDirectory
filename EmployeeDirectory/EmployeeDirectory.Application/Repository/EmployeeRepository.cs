using AutoMapper;
using EmployeeDirectory.Application.DTOs;
using EmployeeDirectory.Application.Exceptions;
using EmployeeDirectory.Application.Interfaces;
using EmployeeDirectory.Application.Interfaces.IRepository;
using EmployeeDirectory.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly IFileUploader _fileUploader;

        public EmployeeRepository(IDBContext dbContext, IMapper mapper, IFileUploader fileUploader)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _fileUploader = fileUploader;
        }

        public async Task<List<Employee>> GetAll(GetAllDTO dto)
        {
            var employees = await _dbContext.Employees.Skip(dto.From).Take(dto.Count)
                .ToListAsync(CancellationToken.None);

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

        public async Task<string> UploadPhoto(UploadPhotoDTO dto, string webRootPath, 
            string hostUrl)
        {
            var employee = await _dbContext.Employees
                .FirstOrDefaultAsync(u => u.Id == dto.EmployeeId,
                    CancellationToken.None);

            if (employee is null)
                throw new NotFoundException(employee);

            _fileUploader.File = dto.Photo;
            _fileUploader.WebRootPath = webRootPath is null
                ? throw new ArgumentException("Корневой путь проекта " +
                "не может быть пустым")
                : webRootPath;
            _fileUploader.AbsolutePath = employee.Id.ToString();

            var fileName = await _fileUploader.UploadFileAsync();

            employee.PhotoUrl = fileName;

            var filePath = UrlParse(hostUrl, employee.Id.ToString(), employee.PhotoUrl);

            await _dbContext.SaveChangesAsync(CancellationToken.None);

            return filePath;

        }

        public async Task Update(UpdateDetailsDTO dto)
        {
            var employee = await _dbContext.Employees
                .FirstOrDefaultAsync(u => u.Id == dto.EmployeeId,
                    CancellationToken.None);

            if (employee is null)
                throw new NotFoundException(employee);

            var isAlreadyExist = _dbContext.Employees.Any(u => u.PhoneNumber == dto.PhoneNumber);

            if (isAlreadyExist)
                throw new AlreadyExistException("Сотрудник с таким номером телефона уже существует");

            employee = _mapper.Map(dto, employee);

            _dbContext.Employees.Update(employee);
            await _dbContext.SaveChangesAsync(CancellationToken.None);

            var asd = await _dbContext.Employees.FirstOrDefaultAsync(u => u.Id == dto.EmployeeId);
        }

        public async Task Delete(Guid employeeId)
        {
            var employee = await _dbContext.Employees
                .FirstOrDefaultAsync(u => u.Id == employeeId,
                    CancellationToken.None);

            if (employee is null)
                throw new NotFoundException(employee);

            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync(CancellationToken.None);
        }

        private string UrlParse(string baseUrl, string baseDir, string url)
        {
            if (url is null || url == string.Empty)
                return null;


            if (baseDir is null)
                return null;

            var baseUri = new Uri(baseUrl);
            var uriResult = new Uri(baseUri, Path.Combine(baseDir, url));
            return uriResult.ToString();
        }
    }
}
