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
    /// Тест метода репозитория <see cref="EmployeeRepository"/> для добавления сотрудника
    /// </summary>
    public class UpdateEmployeeTests : TestCommandBase
    {
        private UpdateDetailsDTO dto;
        private EmployeeRepository employeeRepository;

        public UpdateEmployeeTests()
        {
            dto = new UpdateDetailsDTO
            {
                EmployeeId = TestDBContext.GetEmployeeId(_dbContext),
                FirstName = "Иван",
                LastName = "Иванов",
                MiddleName = "Иванович",
                PhoneNumber = "79998887766",
                Department = "Маркетинг"
            };

            employeeRepository = new EmployeeRepository(_dbContext, _mapper, _fileUploader);
        }

        /// <summary>
        /// Проверяет успешное обновление информации о сотруднике
        /// </summary>
        [Fact]
        public async Task Update_SuccessAsync()
        {
            //Arrange
            //Act
            await employeeRepository.Update(dto);

            //Assert
            var employee = await employeeRepository.GetById(dto.EmployeeId, string.Empty);

            Assert.Matches(dto.Department, employee.Department);
            Assert.Matches(dto.PhoneNumber, employee.PhoneNumber);
            Assert.Matches($"{dto.LastName} {dto.FirstName} {dto.MiddleName}", employee.FullName);
        }

        /// <summary>
        /// Проверяет выбрасывание исключения <see cref="NotFoundException"/>
        /// </summary>
        [Fact]
        public async Task Update_FailOnNotFoundAsync()
        {
            //Arrange
            dto.EmployeeId = Guid.NewGuid();
            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(() => employeeRepository.Update(dto));
        }

        /// <summary>
        /// Проверяет выбрасывание исключения <see cref="AlreadyExistException"/>
        /// </summary>
        [Fact]
        public async Task Update_FailOnNumberAlreadyExistAsync()
        {
            //Arrange
            dto.PhoneNumber = "79999999999";

            //Act
            //Assert
            await Assert.ThrowsAsync<AlreadyExistException>(() => employeeRepository.Update(dto));
        }
    }
}
