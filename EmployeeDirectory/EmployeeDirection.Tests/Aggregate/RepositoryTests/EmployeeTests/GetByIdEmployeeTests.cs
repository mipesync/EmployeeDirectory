using EmployeeDirection.Tests.Common;
using EmployeeDirectory.Application.Exceptions;
using EmployeeDirectory.Application.Repository;
using EmployeeDirectory.Domain;
using System;
using System.Threading.Tasks;
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
            employeeRepository = new EmployeeRepository(_dbContext, _mapper, _fileUploader);
        }

        /// <summary>
        /// Проверяет успешный вывод информации о сотруднике+
        /// </summary>
        [Fact]
        public async Task GetById_SuccessAsync()
        {
            //Arrange
            var employeeeId = TestDBContext.GetEmployeeId(_dbContext);

            //Act
            var result = await employeeRepository.GetById(employeeeId);

            //Assert
            Assert.IsType<Employee>(result);
        }

        /// <summary>
        /// Проверяет выбрасывание исключения <see cref="NotFoundException"/>
        /// </summary>
        [Fact]
        public async void GetById_FailOnNotFoundAsync()
        {
            //Arrange
            var employeeId = Guid.NewGuid();
            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(
                () => employeeRepository.GetById(employeeId));
        }
    }
}
