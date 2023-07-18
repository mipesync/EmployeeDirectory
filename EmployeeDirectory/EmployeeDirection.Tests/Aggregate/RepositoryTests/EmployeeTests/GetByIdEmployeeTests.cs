using EmployeeDirection.Tests.Common;
using EmployeeDirectory.Application.Exceptions;
using EmployeeDirectory.Application.Repository;
using EmployeeDirectory.Domain;
using System;
using Xunit;

namespace EmployeeDirection.Tests.Aggregate.RepositoryTests.EmployeeTests
{
    /// <summary>
    /// Тест метода репозитория <see cref="EmployeeRepository"/> для 
    /// получения информации о сотруднике
    /// </summary>
    public class GetByIdEmployeeTests : TestCommandBase
    {
        private EmployeeRepository employeeRepository;

        public GetByIdEmployeeTests()
        {
            employeeRepository = new EmployeeRepository(_dbContext);
        }

        /// <summary>
        /// Проверяет успешный вывод информации о сотруднике+
        /// </summary>
        [Fact]
        public void GetById_Success()
        {
            //Arrange
            var employeeId = TestDBContext.EmployeeId;

            //Act
            var result = employeeRepository.GetById(employeeId);

            //Assert
            Assert.IsType<Employee>(result);
        }

        /// <summary>
        /// Проверяет выбрасывание исключения <see cref="NotFoundException"/>
        /// </summary>
        [Fact]
        public void GetById_FailOnNotFoundAsync()
        {
            //Arrange
            var employeeId = Guid.NewGuid();
            //Act
            //Assert
            Assert.Throws<NotFoundException>(() => employeeRepository.GetById(employeeId));
        }
    }
}
