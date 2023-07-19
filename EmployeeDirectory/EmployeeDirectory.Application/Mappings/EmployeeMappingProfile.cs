using AutoMapper;
using EmployeeDirectory.Application.DTOs;
using EmployeeDirectory.Domain;
using System;

namespace EmployeeDirectory.Application.Mappings
{
    /// <summary>
    /// Профиль конфигурации маппинга сотрудника
    /// </summary>
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<AddEmployeeDTO, Employee>(MemberList.Source)
                .ForMember(employee => employee.Id, opt => Guid.NewGuid());
        }
    }
}
