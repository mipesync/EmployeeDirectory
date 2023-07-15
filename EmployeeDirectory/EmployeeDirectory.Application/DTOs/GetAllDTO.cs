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
        public int From { get; set; }
        /// <summary>
        /// Какое количество сотрудников вывести
        /// </summary>
        public int Count { get; set; }
    }
}
