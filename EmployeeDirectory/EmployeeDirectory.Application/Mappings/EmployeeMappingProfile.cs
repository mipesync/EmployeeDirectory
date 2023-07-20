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
                .ForMember(employee => employee.Id, opt => Guid.NewGuid())
                .ForMember(employee => employee.FullName, opt => opt.MapFrom(u =>
                    $"{u.LastName} {u.FirstName} {u.MiddleName}"));

            CreateMap<UpdateDetailsDTO, Employee>(MemberList.Source)
                .ForMember(employee => employee.Id, opt => opt.MapFrom(u => u.EmployeeId))
                .ForMember(employee => employee.FullName, opt => opt.MapFrom(u =>
                    $"{u.LastName} {u.FirstName} {u.MiddleName}"))
                .ForMember(employee => employee.FirstName, opt => opt.Condition(u =>
                    u.FirstName != null))
                .ForMember(employee => employee.LastName, opt => opt.Condition(u =>
                    u.LastName != null))
                .ForMember(employee => employee.MiddleName, opt => opt.Condition(u =>
                    u.MiddleName != null))
                .ForMember(employee => employee.Department, opt => opt.Condition(u =>
                    u.Department != null))
                .ForMember(employee => employee.PhoneNumber, opt => opt.Condition(u =>
                    u.PhoneNumber != null));
        }
    }
}
