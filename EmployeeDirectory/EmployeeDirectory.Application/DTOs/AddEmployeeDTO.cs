using System.ComponentModel.DataAnnotations;

namespace EmployeeDirectory.Application.DTOs
{
    /// <summary>
    /// DTO для добавления нового сотрудника
    /// </summary>
    public class AddEmployeeDTO
    {
        /// <summary>
        /// Имя сотрудника
        /// </summary>
        [Required(ErrorMessage = "Имя сотрудника обязательно")]
        public string FirstName { get; set; } = null!;
        /// <summary>
        /// Фамилия сотрудника
        /// </summary>
        [Required(ErrorMessage = "Фамилия сотрудника обязательна")]
        public string LastName { get; set; } = null!;
        /// <summary>
        /// Отчество сотрудника
        /// </summary>
        [Required(ErrorMessage = "Отчество сотрудника обязательно")]
        public string MiddleName { get; set; } = null!;
        /// <summary>
        /// Номер телефона сотрудника
        /// </summary>
        [Required(ErrorMessage = "Номер телефона сотрудника обязателен")]
        public string PhoneNumber { get; set; } = null!;
#nullable enable
        /// <summary>
        /// Название отдела, в котором сотрудник работает
        /// </summary>
        public string? Department { get; set; }
    }
}
