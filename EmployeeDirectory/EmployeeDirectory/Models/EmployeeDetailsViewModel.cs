namespace EmployeeDirectory.Web.Models
{
    /// <summary>
    /// Модель информации о сотруднике
    /// </summary>
    public class EmployeeDetailsViewModel
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
