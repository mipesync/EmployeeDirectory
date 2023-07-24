using EmployeeDirection.Tests.Common;
using EmployeeDirectory.Application.Exceptions;
using EmployeeDirectory.Application.Repository;
using System.Threading.Tasks;
using System;
using Xunit;

namespace EmployeeDirection.Tests.Aggregate.RepositoryTests.EmployeeTests
{
    /// <summary>
    /// Тест метода репозитория <see cref="EmployeeRepository"/> для удаления сотрудника
    /// </summary>
    public class DeleteEmployeeTests : TestCommandBase
    {
        private EmployeeRepository employeeRepository;

        public DeleteEmployeeTests()
        {
            employeeRepository = new EmployeeRepository(_dbContext, _mapper, _fileUploader);
        }

        /// <summary>
        /// Проверяет успешное удаление пользователя
        /// </summary>
        [Fact]
        public async Task Delete_SuccessAsync()
        {

            //Arrange
            var employeeId = TestDBContext.GetEmployeeId(_dbContext);

            //Act
            var result = employeeRepository.Delete(employeeId);

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(
                () => employeeRepository.GetById(employeeId, string.Empty));
        }

        /// <summary>
        /// Проверяет выбрасывание исключения <see cref="NotFoundException"/>
        /// </summary>
        [Fact]
        public async Task Delete_FailOnNotFoundAsync()
        {
            //Arrange
            var employeeId = Guid.NewGuid();

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(
                () => employeeRepository.Delete(employeeId));
        }
    }
}
