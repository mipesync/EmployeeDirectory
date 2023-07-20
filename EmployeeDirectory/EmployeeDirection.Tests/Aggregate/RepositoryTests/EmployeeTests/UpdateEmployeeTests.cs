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
                PhoneNumber = "79999999999",
                Department = "Маркетинг"
            };

            employeeRepository = new EmployeeRepository(_dbContext, _mapper);
        }

        /// <summary>
        /// Проверяет успешное обновление информации о сотруднике
        /// </summary>
        [Fact]
        public void Update_Success()
        {
            //Arrange
            //Act
            var result = employeeRepository.Update(dto);

            //Assert
            Assert.IsType<Task>(result);
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
