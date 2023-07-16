namespace EmployeeDirectory.Application.DTOs
{
    /// <summary>
    /// DTO для обновления информации о сотруднике
    /// </summary>
    public class UpdateDetailsDTO
    {
#nullable enable
        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string? FirstName { get; set; }
        /// <summary>
        /// Фамилия сотрудника
        /// </summary>
        public string? LastName { get; set; }
        /// <summary>
        /// Отчество сотрудника
        /// </summary>
        public string? MiddleName { get; set; }
        /// <summary>
        /// Номер телефона сотрудника
        /// </summary>
        public string? PhoneNumber { get; set; }
        /// <summary>
        /// Название отдела, в котором сотрудник работает
        /// </summary>
        public string? Department { get; set; }
    }
}
