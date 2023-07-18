using EmployeeDirectory.Domain;
using System;

namespace EmployeeDirectory.Application.Exceptions
{
    /// <summary>
    /// Исключение, говорящее о том, что объект не был найден
    /// </summary>
    public class NotFoundException : Exception
    {
        /// <summary>
        /// Исключение с кастомным текстом
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        public NotFoundException(string message) : base(message) { }
        /// <summary>
        /// Исключение с дефолтным текстом ошибки сотрудника
        /// </summary>
        public NotFoundException(Employee employee) : base("Сотрудник не найден") { }
    }
}
