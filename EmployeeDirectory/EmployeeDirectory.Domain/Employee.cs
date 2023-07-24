using System;

namespace EmployeeDirectory.Domain
{
    /// <summary>
    /// Класс сотрудника
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string FirstName { get; set; } = null!;
        /// <summary>
        /// Фамилия сотрудника
        /// </summary>
        public string LastName { get; set; } = null!;
        /// <summary>
        /// Отчество сотрудника
        /// </summary>
        public string MiddleName { get; set; } = null!;
        /// <summary>
        /// ФИО сотрудника
        /// </summary>
        public string FullName { get; set; } = null!;
        /// <summary>
        /// Номер телефона сотрудника
        /// </summary>
        public string PhoneNumber { get; set; } = null!;
#nullable enable
        /// <summary>
        /// Название отдела, в котором сотрудник работает
        /// </summary>
        public string? Department { get; set; }
        /// <summary>
        /// Фотография сотрудника
        /// </summary>
        public string? PhotoUrl { get; set; }
    }
}
