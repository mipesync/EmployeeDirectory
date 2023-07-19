using AutoMapper;
using EmployeeDirectory.Application.Interfaces;
using EmployeeDirectory.Persistence;
using System;

namespace EmployeeDirection.Tests.Common
{
    public class TestCommandBase : IDisposable
    {
        protected readonly DBContext _dbContext;
        protected readonly IMapper _mapper;

        protected TestCommandBase()
        {
            _dbContext = TestDBContext.Create();

            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddMaps(typeof(IDBContext).Assembly);
            });

            _mapper = mapperConfig.CreateMapper();
        }

        public void Dispose()
        {
            TestDBContext.Destroy(_dbContext);
        }
    }
}
