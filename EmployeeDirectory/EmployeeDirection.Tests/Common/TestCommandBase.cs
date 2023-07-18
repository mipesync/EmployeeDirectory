using EmployeeDirectory.Persistence;
using System;

namespace EmployeeDirection.Tests.Common
{
    public class TestCommandBase : IDisposable
    {
        protected readonly DBContext _dbContext;

        protected TestCommandBase()
        {
            _dbContext = TestDBContext.Create();
        }

        public void Dispose()
        {
            TestDBContext.Destroy(_dbContext);
        }
    }
}
