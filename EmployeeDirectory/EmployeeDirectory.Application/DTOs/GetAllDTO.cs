using System.ComponentModel.DataAnnotations;

namespace EmployeeDirectory.Application.DTOs
{
    /// <summary>
    /// DTO для вывода списка сотрудников
    /// </summary>
    public class GetAllDTO
    {
        /// <summary>
        /// С какого количества начинать выборку
        /// </summary>
        [Required(ErrorMessage = "Параметр \"From\" обязателен")]
        public int From { get; set; }
        /// <summary>
        /// Какое количество сотрудников вывести
        /// </summary>
        [Required(ErrorMessage = "Количество сотрудников обязательно")]
        public int Count { get; set; }
    }
}
