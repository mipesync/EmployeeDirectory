namespace EmployeeDirectory.Application.DTOs.ReturnDTO
{
    public class EmployeeLookup
    {
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
