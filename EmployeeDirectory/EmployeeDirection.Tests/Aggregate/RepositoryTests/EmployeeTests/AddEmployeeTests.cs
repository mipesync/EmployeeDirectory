using EmployeeDirection.Tests.Common;
using EmployeeDirectory.Application.DTOs;
using EmployeeDirectory.Application.Exceptions;
using EmployeeDirectory.Application.Repository;
using System;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeDirection.Tests.Aggregate.RepositoryTests.EmployeeTests
{
    /// <summary>
    /// Тест метода репозитория <see cref="EmployeeRepository"/> для 
    /// добавления сотрудника
    /// </summary>
    public class AddEmployeeTests : TestCommandBase
    {
        private AddEmployeeDTO dto;
        private EmployeeRepository employeeRepository;

        public AddEmployeeTests()
        {
            dto = new AddEmployeeDTO
            {
                FirstName = "Иван",
                LastName = "Иванов",
                MiddleName = "Иванович",
                PhoneNumber = "79998887766",
                Department = "Маркетинг"
            };

            employeeRepository = new EmployeeRepository(_dbContext, _mapper, _fileUploader);
        }
        
        /// <summary>
        /// Проверяет успешное добавление сотрудника
        /// </summary>
        [Fact]
        public async Task Add_SuccessAsync()
        {
            //Arrange
            //Act
            var result = await employeeRepository.Add(dto);

            //Assert
            Assert.IsType<Guid>(result);
        }

        /// <summary>
        /// Проверяет выбрасывание исключения <see cref="AlreadyExistException"/>
        /// </summary>
        [Fact]
        public async Task Add_FailOnNumberAlreadyExistAsync()
        {
            //Arrange
            dto.PhoneNumber = "79999999999";

            //Act
            //Assert
            await Assert.ThrowsAsync<AlreadyExistException>(
                () => employeeRepository.Add(dto));
        }
    }
}
